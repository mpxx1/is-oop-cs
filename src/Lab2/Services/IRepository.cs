using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IRepository<T>
    where T : IHaveName
{
    public bool Add(T obj);
    public bool Remove(string objName);
    public T? GetByName(string objName);
    public void Update(T obj);
}