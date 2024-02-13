using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class PciEVersion
{
    public PciEVersion(string version)
    {
        if (string.IsNullOrEmpty(version))
            throw new PciBuildException();

        Version = version;
    }

    public string Version { get; }
}