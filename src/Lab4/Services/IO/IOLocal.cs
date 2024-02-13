using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

public class IOLocal : IIOSystem
{
    public ConnectionMode ConnectionMode => ConnectionMode.Local;

    public void Write(string text)
    {
        System.Console.WriteLine(text);
    }

    public string Read()
    {
        return System.Console.ReadLine() ?? string.Empty;
    }
}