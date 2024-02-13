using Domain.Model.Enums;
using Domain.Model.Interfaces;

namespace Domain.Model.Implementations;

public class BankTransaction : IBankTransaction
{
    public BankTransaction(AtmOperation operationType, decimal amount, DateTime dateTime)
    {
        AtmOperation = operationType;
        Amount = amount;
        DateTime = dateTime;
    }

    public AtmOperation AtmOperation { get; }
    public decimal Amount { get; }
    public DateTime DateTime { get; }
}