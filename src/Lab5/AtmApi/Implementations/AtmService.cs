using AtmApi.Interfaces;
using Domain.Model.Interfaces;
using Domain.Ports.Primary;

namespace AtmApi.Implementations;

public class AtmService : IAtmService
{
    private IAtmState _atmState;

    public AtmService(IAtmState atmState)
    {
        _atmState = atmState;
    }

    public async Task UserLogin(long account, short pin)
    {
        _atmState = await _atmState
            .UserLogin(account, pin)
            .ConfigureAwait(false);
    }

    public async Task AdminLogin(string userName, string passwd)
    {
        _atmState = await _atmState
            .AdminLogin(userName, passwd)
            .ConfigureAwait(false);
    }

    public async Task Logout()
    {
        _atmState = await _atmState
            .Logout()
            .ConfigureAwait(false);
    }

    public async Task<IUserResult> CreateUser(string firstName, string lastName)
    {
        return await _atmState
            .CreateUser(firstName, lastName)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmount()
    {
        return await _atmState
            .GetCashAmount()
            .ConfigureAwait(false);
    }

    public async Task Withdraw(decimal amount)
    {
        await _atmState
            .Withdraw(amount)
            .ConfigureAwait(false);
    }

    public async Task Refill(decimal amount)
    {
        await _atmState
            .Refill(amount)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<IBankTransaction>> History()
    {
        return await _atmState
            .History()
            .ConfigureAwait(false);
    }

    public async Task CreateAdmin(string firstName, string lastName, string systemName, string passwd)
    {
        await _atmState
            .CreateAdmin(firstName, lastName, systemName, passwd)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmountOf(long userBankAccount)
    {
        long userId;
        try
        {
            userId = await _atmState
                .GetUserIdByBankAccount(userBankAccount)
                .ConfigureAwait(false);
        }
        catch (System.Exception)
        {
            throw;
        }

        return await _atmState
            .GetCashAmountOf(userId)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<IBankTransaction>> HistoryOf(long userBankAccount)
    {
        long userId;
        try
        {
            userId = await _atmState
                .GetUserIdByBankAccount(userBankAccount)
                .ConfigureAwait(false);
        }
        catch (System.Exception)
        {
            throw;
        }

        return await _atmState
            .HistoryOf(userId)
            .ConfigureAwait(false);
    }

    public async Task WithdrawFrom(long userBankAccount, decimal amount)
    {
        long userId;
        try
        {
            userId = await _atmState
                .GetUserIdByBankAccount(userBankAccount)
                .ConfigureAwait(false);
        }
        catch (System.Exception)
        {
            throw;
        }

        await _atmState
            .WithdrawFrom(userId, amount)
            .ConfigureAwait(false);
    }

    public async Task RefillTo(long userBankAccount, decimal amount)
    {
        long userId;
        try
        {
            userId = await _atmState
                .GetUserIdByBankAccount(userBankAccount)
                .ConfigureAwait(false);
        }
        catch (System.Exception)
        {
            throw;
        }

        await _atmState
            .RefillTo(userId, amount)
            .ConfigureAwait(false);
    }
}