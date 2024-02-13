using Domain.Model.Interfaces;

namespace Domain.Ports.Primary;

public interface IAtmService
{
    public Task UserLogin(long account, short pin);
    public Task AdminLogin(string userName, string passwd);
    public Task Logout();

    public Task<IUserResult> CreateUser(string firstName, string lastName);

    // user zone
    public Task<decimal> GetCashAmount();
    public Task Withdraw(decimal amount);
    public Task Refill(decimal amount);
    public Task<IEnumerable<IBankTransaction>> History();

    // admin zone
    public Task CreateAdmin(string firstName, string lastName, string systemName, string passwd);
    public Task<decimal> GetCashAmountOf(long userBankAccount);
    public Task<IEnumerable<IBankTransaction>> HistoryOf(long userBankAccount);
    public Task WithdrawFrom(long userBankAccount, decimal amount);
    public Task RefillTo(long userBankAccount, decimal amount);
}