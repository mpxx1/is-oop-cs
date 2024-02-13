using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public enum BiosType
{
    Bios,
    Efi,
    Uefi,
    AppleBios,
}

public class Bios
{
    public Bios(BiosType type, string name, string version, IList<string> supportedChips)
    {
        if (string.IsNullOrEmpty(version) || string.IsNullOrEmpty(name))
            throw new BiosBuildException();

        Name = name;
        Type = type;
        Version = version;
        SupportedChips = supportedChips ?? throw new BiosBuildException();
    }

    public BiosType Type { get; }
    public string Version { get; }
    public IList<string> SupportedChips { get; }
    public string Name { get; }
}