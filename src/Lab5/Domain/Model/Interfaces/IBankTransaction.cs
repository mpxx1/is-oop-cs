using Domain.Model.Enums;

namespace Domain.Model.Interfaces;

public interface IBankTransaction
{
    public AtmOperation AtmOperation { get; }
    public decimal Amount { get; }
    public DateTime DateTime { get; }
}