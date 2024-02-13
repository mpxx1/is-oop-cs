using AtmApi.Exception;
using AtmApi.Interfaces;
using AtmRepositoryAdapter;
using DbRepositoryImpl.Exceptions;
using Domain.Model.Interfaces;

namespace AtmApi.Implementations;

public class UserAtmState : IAtmState
{
    private readonly IAtmRepository _repository;
    private readonly ISystemAccount _accountInfo;

    public UserAtmState(ISystemAccount accountInfo, IAtmRepository repository)
    {
        _repository = repository;
        _accountInfo = accountInfo;
    }

    public Task<IAtmState> UserLogin(long account, short pin)
    {
        throw new NotPermitedException();
    }

    public Task<IAtmState> AdminLogin(string userName, string passwd)
    {
        throw new NotPermitedException();
    }

    public Task<IAtmState> Logout()
    {
        return new Task<IAtmState>(() => new UnauthorizedAtmState(_repository));
    }

    public Task<IUserResult> CreateUser(string firstName, string lastName)
    {
        throw new NotPermitedException();
    }

    public async Task<decimal> GetCashAmount()
    {
        return await _repository
            .GetCashAmount(_accountInfo.SystemId)
            .ConfigureAwait(false);
    }

    public async Task Withdraw(decimal amount)
    {
        decimal current = await _repository
            .GetCashAmount(_accountInfo.SystemId)
            .ConfigureAwait(false);

        if (current < amount) throw new InsufficientFundsException();

        await _repository
            .Withdraw(_accountInfo.SystemId, amount)
            .ConfigureAwait(false);
    }

    public async Task Refill(decimal amount)
    {
        await _repository
            .Refill(_accountInfo.SystemId, amount)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<IBankTransaction>> History()
    {
        IEnumerable<IBankTransaction> history = await _repository
            .GetTransactionHistory(_accountInfo.SystemId)
            .ConfigureAwait(false);

        return history;
    }

    public Task CreateAdmin(string firstName, string lastName, string systemName, string passwd)
    {
        throw new NotPermitedException();
    }

    public Task<decimal> GetCashAmountOf(long user)
    {
        throw new NotPermitedException();
    }

    public Task<IEnumerable<IBankTransaction>> HistoryOf(long userId)
    {
        throw new NotPermitedException();
    }

    public Task WithdrawFrom(long userId, decimal amount)
    {
        throw new NotPermitedException();
    }

    public Task RefillTo(long userId, decimal amount)
    {
        throw new NotPermitedException();
    }

    public Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        throw new NotPermitedException();
    }
}