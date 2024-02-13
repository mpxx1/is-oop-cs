using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Display;

public class Display : IMessageReceiver
{
    private DisplayLogger _logger = new();
    public string Name => "Display";
    public void Receive(IMessage message)
    {
        _logger.PrintMessages(new List<IMessage> { message, });
    }
}