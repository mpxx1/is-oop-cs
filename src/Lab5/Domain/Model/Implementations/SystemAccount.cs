using Domain.Model.Enums;
using Domain.Model.Interfaces;

namespace Domain.Model.Implementations;

public class SystemAccount : ISystemAccount
{
    public SystemAccount(long systemId, SystemRole systemRole)
    {
        SystemId = systemId;
        SystemRole = systemRole;
    }

    public long SystemId { get; }
    public SystemRole SystemRole { get; }
}