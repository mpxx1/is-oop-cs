using System.Security.Authentication;
using AtmApi.Exception;
using AtmApi.Interfaces;
using AtmRepositoryAdapter;
using Domain.Model.Interfaces;

namespace AtmApi.Implementations;

public class UnauthorizedAtmState : IAtmState
{
    private readonly IAtmRepository _repository;

    public UnauthorizedAtmState(IAtmRepository repository)
    {
        _repository = repository;
    }

    public async Task<IAtmState> UserLogin(long account, short pin)
    {
        try
        {
            ISystemAccount accountInfo = await _repository
                .VerifyUser(account, pin)
                .ConfigureAwait(false);

            return new UserAtmState(accountInfo, _repository);
        }
        catch (AuthenticationException)
        {
            return this;
        }
    }

    public async Task<IAtmState> AdminLogin(string userName, string passwd)
    {
        try
        {
            ISystemAccount accountInfo = await _repository
                .VerifyAdmin(userName, passwd)
                .ConfigureAwait(false);

            return new AdminAtmState(_repository);
        }
        catch (AuthenticationException)
        {
            return this;
        }
    }

    public Task<IAtmState> Logout()
    {
        throw new NotPermitedException();
    }

    public async Task<IUserResult> CreateUser(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Length > 20)
            throw new NameLengthException("Incorrect length of first name");

        if (string.IsNullOrEmpty(lastName) || lastName.Length > 20)
            throw new NameLengthException("Incorrect length of last name");

        IUserResult user = await _repository
            .SaveUser(firstName, lastName)
            .ConfigureAwait(false);

        return user;
    }

    public Task<decimal> GetCashAmount()
    {
        throw new NotPermitedException();
    }

    public Task Withdraw(decimal amount)
    {
        throw new NotPermitedException();
    }

    public Task Refill(decimal amount)
    {
        throw new NotPermitedException();
    }

    public Task<IEnumerable<IBankTransaction>> History()
    {
        throw new NotPermitedException();
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