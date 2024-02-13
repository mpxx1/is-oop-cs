namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class UserMessage : IUserMessageWrapper
{
    public UserMessage(
        string title,
        string body,
        ImportantLevel importantLevel)
    {
        Title = title;
        Body = body;
        ImportantLevel = importantLevel;
        ReadStatus = ReadStatus.UnRead;
    }

    public string Title { get; }
    public string Body { get; }
    public ImportantLevel ImportantLevel { get; }
    public ReadStatus ReadStatus { get; private set; }

    public void SetRead()
    {
        ReadStatus = ReadStatus.Read;
    }
}