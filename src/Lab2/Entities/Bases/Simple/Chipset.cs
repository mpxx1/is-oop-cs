using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class Chipset
{
    public Chipset(string name, IList<int> frequencies, bool xmpSupport)
    {
        if (frequencies == null || frequencies.Count.Equals(0) || string.IsNullOrEmpty(name))
            throw new ChipsetBuildException();

        Name = name;
        Frequencies = frequencies;
        XmpSupport = xmpSupport;
    }

    public IList<int> Frequencies { get; }
    public bool XmpSupport { get; }
    public string Name { get; }
}