using Domain.Model.Enums;

namespace Domain.Model.Interfaces;

public interface ISystemAccount
{
    public long SystemId { get; }
    public SystemRole SystemRole { get; }
}