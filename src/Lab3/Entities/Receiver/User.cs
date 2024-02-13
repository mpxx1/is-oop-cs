using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class User : IMessageReceiver
{
    private IList<IUserMessageWrapper> _messages = new List<IUserMessageWrapper>();
    private ILogger _userLogger = new UserMessagesLogger();
    public User(string username, string? attributes = null)
    {
        Name = username;
        Attributes = attributes;
    }

    public IList<IUserMessageWrapper> Messages => _messages;

    public string Name { get; }
    private string? Attributes { get; }
    public void Receive(IMessage message)
    {
        if (message == null) return;

        _messages.Add(
            new UserMessage(
                message.Title, message.Body, message.ImportantLevel));
    }

    public void ReadMessage(int id)
    {
        _messages[id].SetRead();
    }

    public void PrintAttributes()
    {
        if (Attributes != null)
            System.Console.WriteLine(Attributes);
    }

    public void PrintMessages()
    {
        _userLogger.PrintMessages(new List<IMessage>(_messages));
    }
}