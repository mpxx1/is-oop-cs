using Domain.Model.Interfaces;

namespace Domain.Model.Implementations;

public class UserResult : IUserResult
{
    public UserResult(long userAccount, short pin)
    {
        UserAccount = userAccount;
        Pin = pin;
    }

    public long UserAccount { get; }
    public short Pin { get; }
}