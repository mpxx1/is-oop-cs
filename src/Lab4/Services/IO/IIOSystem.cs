using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

public interface IIOSystem
{
    public ConnectionMode ConnectionMode { get; }
    public void Write(string text);
    public string Read();
}