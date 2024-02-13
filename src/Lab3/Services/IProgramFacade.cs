using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface IProgramFacade
{
    public void AddTopic(ITopic topic);
    public void SendMessageTo(string receiver, IMessage message);
}