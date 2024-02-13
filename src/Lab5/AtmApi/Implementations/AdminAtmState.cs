using AtmApi.Exception;
using AtmApi.Interfaces;
using AtmRepositoryAdapter;
using Domain.Model.Interfaces;

namespace AtmApi.Implementations;

public class AdminAtmState : IAtmState
{
    private readonly IAtmRepository _repository;

    public AdminAtmState(IAtmRepository repository)
    {
        _repository = repository;
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

    public async Task CreateAdmin(string firstName, string lastName, string systemName, string passwd)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Length > 20)
            throw new NameLengthException("Incorrect length of first name");

        if (string.IsNullOrEmpty(lastName) || lastName.Length > 20)
            throw new NameLengthException("Incorrect length of last name");

        if (string.IsNullOrEmpty(systemName) || systemName.Length > 20)
            throw new NameLengthException("Incorrect length of system name");

        if (string.IsNullOrEmpty(passwd) || passwd.Length < 8 || passwd.Length > 20)
            throw new PasswdBodyException("Incorrect length of password, must be more than 7 and less than 20");

        bool hasUppercase = passwd.Any(char.IsUpper);
        bool hasLowercase = passwd.Any(char.IsLower);
        bool hasSpecialChars = passwd.Any(char.IsPunctuation);

        if (!(hasUppercase && hasLowercase && hasSpecialChars))
            throw new PasswdBodyException("Password must contain lower, upper and special characters");

        await _repository
            .SaveAdmin(firstName, lastName, systemName, passwd)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmountOf(long user)
    {
        return await _repository
            .GetCashAmount(user)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<IBankTransaction>> HistoryOf(long userId)
    {
        return await _repository
            .GetTransactionHistory(userId)
            .ConfigureAwait(false);
    }

    public async Task WithdrawFrom(long userId, decimal amount)
    {
        await _repository
            .Withdraw(userId, amount)
            .ConfigureAwait(false);
    }

    public async Task RefillTo(long userId, decimal amount)
    {
        await _repository
            .Refill(userId, amount)
            .ConfigureAwait(false);
    }

    public async Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        return await _repository
            .GetUserIdByBankAccount(bankAccount)
            .ConfigureAwait(false);
    }
}