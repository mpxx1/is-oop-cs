using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class WifiVersion
{
    public WifiVersion(string version)
    {
        if (string.IsNullOrEmpty(version))
            throw new WifiUnitBuildException("Wrong Wifi Version");

        if (version.Length > 3)
            throw new WifiUnitBuildException("Wrong Wifi Version");

        Version = version;
    }

    public string Version { get; }
}