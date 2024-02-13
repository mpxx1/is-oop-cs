using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Messenger;

public abstract class Messenger : IMessageReceiver
{
    private readonly ILogger _messengerLogger = new MessengerLogger();
    public abstract string Name { get; }
    public void Receive(IMessage message)
    {
        if (message == null) return;

        System.Console.WriteLine($"{Name}:");
        _messengerLogger.PrintMessages(new List<IMessage> { message, });
    }
}