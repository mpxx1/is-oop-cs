using Domain.Model.Interfaces;
using Domain.Ports.Secondary;

namespace AtmRepositoryAdapter;

public class AtmRepository : IAtmRepository
{
    private IDbRepository _repository;

    public AtmRepository(IDbRepository repository)
    {
        _repository = repository;
    }

    public async Task<ISystemAccount> VerifyUser(long bankAccount, short pin)
    {
        return await _repository
            .VerifyUser(bankAccount, pin)
            .ConfigureAwait(false);
    }

    public async Task<ISystemAccount> VerifyAdmin(string systemName, string passwd)
    {
        return await _repository
            .VerifyAdmin(systemName, passwd)
            .ConfigureAwait(false);
    }

    public async Task<IUserResult> SaveUser(string firstName, string lastName)
    {
        return await _repository
            .SaveUser(firstName, lastName)
            .ConfigureAwait(false);
    }

    public async Task SaveAdmin(string firstName, string lastName, string systemName, string passwd)
    {
        await _repository
            .SaveAdmin(firstName, lastName, systemName, passwd)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmount(long accountId)
    {
        return await _repository
            .GetCashAmount(accountId)
            .ConfigureAwait(false);
    }

    public async Task Withdraw(long accountId, decimal amount)
    {
        await _repository
            .Withdraw(accountId, amount)
            .ConfigureAwait(false);
    }

    public async Task Refill(long accountId, decimal amount)
    {
        await _repository
            .Refill(accountId, amount)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<IBankTransaction>> GetTransactionHistory(long accountId)
    {
        IEnumerable<IBankTransaction> history = await _repository
            .GetTransactionHistory(accountId)
            .ConfigureAwait(false);

        return history;
    }

    public async Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        return await _repository
            .GetUserIdByBankAccount(bankAccount)
            .ConfigureAwait(false);
    }
}