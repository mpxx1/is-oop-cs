using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class CpuSocket
{
    public CpuSocket(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new SocketBuildException();

        Name = name;
    }

    public string Name { get; }
}