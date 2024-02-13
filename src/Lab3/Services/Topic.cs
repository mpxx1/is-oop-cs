using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Topic : ITopic
{
    private IMessageReceiver _receiver;
    public Topic(
        string topicName,
        IMessageReceiver receiver,
        ImportantLevel importantLevel)
    {
        TopicName = topicName;
        _receiver = receiver;
        ImportantLevel = importantLevel;
    }

    public string TopicName { get; }
    public string Name => _receiver.Name;
    public ImportantLevel ImportantLevel { get; }

    public void SendMessage(IMessage message)
    {
        if (message == null) return;

        if (message.ImportantLevel == ImportantLevel)
            _receiver.Receive(message);
    }
}