using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class Group : IMessageReceiver
{
    private readonly IList<IMessageReceiver> _receivers;

    public Group(string name, IList<IMessageReceiver> receivers)
    {
        Name = name;
        _receivers = receivers;
    }

    public string Name { get; }
    public void Receive(IMessage message)
    {
        foreach (IMessageReceiver receiver in _receivers)
        {
            receiver.Receive(message);
        }
    }
}