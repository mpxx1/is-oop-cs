using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

public class IOVirtual : IIOSystem
{
    private string _buf = string.Empty;

    public ConnectionMode ConnectionMode => ConnectionMode.Virtual;

    public void Write(string text)
    {
        string tmp = text;  // made to avoid an error
        _buf = tmp;
    }

    public string Read()
    {
        string tmp = _buf;  // made to avoid an error
        return tmp;
    }
}