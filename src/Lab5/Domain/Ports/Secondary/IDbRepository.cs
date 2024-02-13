using Domain.Model.Interfaces;

namespace Domain.Ports.Secondary;

public interface IDbRepository
{
    public Task<ISystemAccount> VerifyUser(long bankAccount, short pin);
    public Task<ISystemAccount> VerifyAdmin(string systemName, string passwd);
    public Task<IUserResult> SaveUser(string firstName, string lastName);
    public Task SaveAdmin(string firstName, string lastName, string systemName, string passwd);
    public Task<decimal> GetCashAmount(long accountId);
    public Task Withdraw(long accountId, decimal amount);
    public Task Refill(long accountId, decimal amount);
    public Task<IEnumerable<IBankTransaction>> GetTransactionHistory(long accountId);
    public Task<long> GetUserIdByBankAccount(long bankAccount);
}