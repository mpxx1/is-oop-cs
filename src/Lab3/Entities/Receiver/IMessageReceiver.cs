namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public interface IMessageReceiver : IReceiverName
{
    public void Receive(IMessage message);
}