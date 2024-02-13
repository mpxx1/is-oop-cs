using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface IRepository<T>
    where T : IReceiverName
{
    public void Add(T obj);
    public void Delete(string name);
    public T? GetByName(string name);
    public void Update(T obj);
}