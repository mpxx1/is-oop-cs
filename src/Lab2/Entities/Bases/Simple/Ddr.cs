using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class Ddr
{
    public Ddr(string version)
    {
        if (string.IsNullOrEmpty(version))
            throw new DdrBuildException();

        Version = version;
    }

    public string Version { get; }
}