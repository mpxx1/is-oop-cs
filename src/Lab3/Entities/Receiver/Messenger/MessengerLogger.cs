using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Messenger;

public class MessengerLogger : ILogger
{
    public void PrintMessages(IList<IMessage> messages)
    {
        if (messages == null) return;

        foreach (IMessage message in messages)
        {
            System.Console.WriteLine($"{message.Title}\n{message.Body}");
        }
    }
}