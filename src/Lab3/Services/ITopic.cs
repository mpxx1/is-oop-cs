using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface ITopic : IReceiverName
{
    public string TopicName { get; }
    public ImportantLevel ImportantLevel { get; }
    public void SendMessage(IMessage message);
}