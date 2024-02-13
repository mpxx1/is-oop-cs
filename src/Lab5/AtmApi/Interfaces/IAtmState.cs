using Domain.Model.Interfaces;

namespace AtmApi.Interfaces;

public interface IAtmState
{
    // changes state
    public Task<IAtmState> UserLogin(long account, short pin);
    public Task<IAtmState> AdminLogin(string userName, string passwd);
    public Task<IAtmState> Logout();

    public Task<IUserResult> CreateUser(string firstName, string lastName);

    // user zone
    public Task<decimal> GetCashAmount();
    public Task Withdraw(decimal amount);
    public Task Refill(decimal amount);
    public Task<IEnumerable<IBankTransaction>> History();

    // admin zone
    public Task CreateAdmin(string firstName, string lastName, string systemName, string passwd);
    public Task<decimal> GetCashAmountOf(long user);
    public Task<IEnumerable<IBankTransaction>> HistoryOf(long userId);
    public Task WithdrawFrom(long userId, decimal amount);
    public Task RefillTo(long userId, decimal amount);
    public Task<long> GetUserIdByBankAccount(long bankAccount);
}