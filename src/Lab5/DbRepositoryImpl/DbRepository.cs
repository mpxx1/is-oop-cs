using System.Security.Cryptography;
using DbRepositoryImpl.Exceptions;
using Domain.Model.Enums;
using Domain.Model.Implementations;
using Domain.Model.Interfaces;
using Domain.Ports.Secondary;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace DbRepositoryImpl;

public class DbRepository : IDbRepository
{
    private IPostgresConnectionProvider _connectionProvider;

    public DbRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<ISystemAccount> VerifyUser(long bankAccount, short pin)
    {
        const string sql = $"""
                            select account_id
                            from user_access
                            where bank_account = :bank_account
                            and pin = :pin
                            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command
            .AddParameter("bank_account", bankAccount)
            .AddParameter("pin", pin);

        using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync()
            .ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            throw new AuthenticationException();

        return new SystemAccount(
            reader.GetInt64(0),
            SystemRole.User);
    }

    public async Task<ISystemAccount> VerifyAdmin(string systemName, string passwd)
    {
        const string sql = $"""
                            select account_id
                            from admin_access
                            where system_name = :systemName
                            and passwd = :passwd;
                            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command
            .AddParameter("systemName", systemName)
            .AddParameter("passwd", passwd);

        using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync()
            .ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            throw new AuthenticationException();

        return new SystemAccount(
            reader.GetInt64(0),
            SystemRole.Admin);
    }

    [Obsolete("Obsolete")]
    public async Task<IUserResult> SaveUser(string firstName, string lastName)
    {
        long accountId = Guid.NewGuid().ToByteArray().Aggregate(0L, (current, b) => (current * 256) + b);
        accountId = Math.Abs(accountId);

        long bankAccount = Guid.NewGuid().ToByteArray().Aggregate(0L, (current, b) => (current * 256) + b);
        bankAccount = Math.Abs(bankAccount);

        byte[] bytes = new byte[2];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(bytes);
        }

        short pin = BitConverter.ToInt16(bytes, 0);
        pin = Math.Abs(pin);
        pin %= 10000;

        const string sql = """
                            insert into accounts 
                            overriding system value 
                            values (:accountId, :firstName, :lastName, :user_role);

                            insert into user_access 
                            overriding system value 
                            values (:accountId, :bankAccount, :pin);

                            insert into user_amount 
                            values (:accountId, 0);
                            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command
            .AddParameter("accountId", accountId)
            .AddParameter("firstName", firstName)
            .AddParameter("lastName", lastName)
            .AddParameter("bankAccount", bankAccount)
            .AddParameter("pin", pin)
            .AddParameter("user_role", SystemRole.User);

        await command
            .ExecuteNonQueryAsync()
            .ConfigureAwait(false);

        return new UserResult(bankAccount, pin);
    }

    public async Task SaveAdmin(string firstName, string lastName, string systemName, string passwd)
    {
        long accountId = Guid.NewGuid().ToByteArray().Aggregate(0L, (current, b) => (current * 256) + b);

        const string sql = """
                           insert into accounts
                           overriding system value
                           values (:accountId, :firstName, :lastName, :user_role);

                           insert into admin_access
                           overriding system value
                           values (:accountId, :system_name, :passwd);
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command
            .AddParameter("accountId", accountId)
            .AddParameter("firstName", firstName)
            .AddParameter("lastName", lastName)
            .AddParameter("system_name", systemName)
            .AddParameter("passwd", passwd)
            .AddParameter("user_role", SystemRole.Admin);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmount(long accountId)
    {
        const string sql = """
                           select amount
                           from user_amount
                           where account_id = :account_id
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("account_id", accountId);

        using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync()
            .ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            throw new AuthenticationException();

        return reader.GetDecimal(0);
    }

    public async Task Withdraw(long accountId, decimal amount)
    {
        decimal current = await GetCashAmount(accountId)
            .ConfigureAwait(false);

        if (current < amount) throw new InsufficientFundsException();

        current -= amount;

        const string sql = """
                           update user_amount
                           set amount = :new_amount
                           where account_id = :account;
                           
                           insert into atm_history
                           values (:account, :operation_type, :amount, :operation_time)
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command
            .AddParameter("account", accountId)
            .AddParameter("new_amount", current)
            .AddParameter("operation_type", AtmOperation.Withdraw)
            .AddParameter("amount", amount)
            .AddParameter("operation_time", DateTime.Now);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task Refill(long accountId, decimal amount)
    {
        decimal current = await GetCashAmount(accountId)
            .ConfigureAwait(false);

        decimal newAmount = current + amount;
        const string sql = """
                           update user_amount
                           set amount = :new_amount
                           where account_id = :account;

                           insert into atm_history
                           values (:account, :operation_type, :amount, :operation_time);
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command
            .AddParameter("operation_type", AtmOperation.Refill)
            .AddParameter("account", accountId)
            .AddParameter("new_amount", newAmount)
            .AddParameter("amount", amount)
            .AddParameter("operation_time", DateTime.Now);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<IBankTransaction>> GetTransactionHistory(long accountId)
    {
        const string sql = """
                           select * 
                           from atm_history
                           where account_id = :accountId
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync()
            .ConfigureAwait(false);

        var transactions = new List<IBankTransaction>();

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            transactions.Add(
                new BankTransaction(
                    await reader
                        .GetFieldValueAsync<AtmOperation>(1)
                        .ConfigureAwait(false),
                    reader.GetDecimal(2),
                    reader.GetDateTime(3)));
        }

        return transactions;
    }

    public async Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        const string sql = """
                           select account_id
                           from user_access
                           where bank_account = :bankAccount;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("bankAccount", bankAccount);

        using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync()
            .ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            throw new NoSuchUserException();

        return reader.GetInt64(0);
    }
}