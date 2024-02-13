namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public enum ReadStatus
{
    Read,
    UnRead,
}

public interface IUserMessageWrapper : IMessage
{
    public ReadStatus ReadStatus { get; }
    public void SetRead();
}