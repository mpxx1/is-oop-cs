namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message : IMessage
{
    public Message(
        string title,
        string body,
        ImportantLevel importantLevel)
    {
        Title = title;
        Body = body;
        ImportantLevel = importantLevel;
    }

    public string Title { get; }
    public string Body { get; }
    public ImportantLevel ImportantLevel { get; }
}