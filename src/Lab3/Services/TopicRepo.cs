using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class TopicRepo : IRepository<ITopic>
{
    private readonly IList<ITopic> _topics;

    public TopicRepo(IList<ITopic> topics)
    {
        _topics = topics;
    }

    public void Add(ITopic obj)
    {
        if (!_topics.Contains(obj))
            _topics.Add(obj);
    }

    public void Delete(string name)
    {
        ITopic? topicToDelete = _topics.FirstOrDefault(topic => topic.Name == name);
        if (topicToDelete != null)
            _topics.Remove(topicToDelete);
    }

    public ITopic? GetByName(string name)
    {
        return _topics.FirstOrDefault(topic => topic.Name == name);
    }

    public void Update(ITopic obj)
    {
        if (obj == null)
            return;

        for (int i = 0; i < _topics.Count; ++i)
        {
            if (obj.Name != _topics[i].Name) continue;
            _topics[i] = obj;
            break;
        }
    }
}