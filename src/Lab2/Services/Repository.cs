using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Repository<T> : IRepository<T>
    where T : IHaveName
{
    private IList<T> _list;

    public Repository(IList<T> list)
    {
        _list = list;
    }

    public bool Add(T obj)
    {
        if (_list.Contains(obj)) return false;
        _list.Add(obj);
        return true;
    }

    public bool Remove(string objName)
    {
        T? objToRemove = _list.FirstOrDefault(sth => sth.Name == objName);
        if (objToRemove == null) return false;
        _list.Remove(objToRemove);
        return true;
    }

    public T? GetByName(string objName)
    {
        return _list.FirstOrDefault(sth => sth.Name == objName);
    }

    public void Update(T obj)
    {
        for (int i = 0; i < _list.Count; ++i)
        {
            if (obj.Name != _list[i].Name) continue;
            _list[i] = obj;
            break;
        }
    }
}