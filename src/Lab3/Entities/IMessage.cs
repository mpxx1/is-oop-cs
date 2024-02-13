namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public enum ImportantLevel
{
    High,
    Medium,
    Low,
}

public interface IMessage
{
    public string Title { get; }
    public string Body { get; }
    public ImportantLevel ImportantLevel { get; }
}