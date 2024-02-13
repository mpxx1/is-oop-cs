using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class UserMessagesLogger : ILogger
{
    public void PrintMessages(IList<IMessage> messages)
    {
        if (messages == null) return;
        IList<IUserMessageWrapper> userMessages = messages.OfType<IUserMessageWrapper>().ToList();

        for (int i = 0; i < userMessages.Count; ++i)
        {
            Console.WriteLine($"{i}: {userMessages[i].ReadStatus} : {userMessages[i]}");
        }
    }
}