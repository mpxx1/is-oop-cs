using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class ProgramFacade : IProgramFacade
{
    private TopicRepo _repo;

    public ProgramFacade(IList<ITopic> topics)
    {
        _repo = new TopicRepo(topics);
    }

    public void AddTopic(ITopic topic)
    {
        _repo.Add(topic);
    }

    public void SendMessageTo(string receiver, IMessage message)
    {
        ITopic? topic = _repo.GetByName(receiver);
        if (topic == null) return;

        topic.SendMessage(message);
    }
}