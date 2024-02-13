using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class XmpProfile : IHaveName
{
    public XmpProfile(string name, IList<int> timeing, int voltage, int frequency)
    {
        if (string.IsNullOrEmpty(name))
            throw new XmpBuildException();

        if (timeing is not { Count: 4 })
            throw new XmpBuildException();

        if (voltage <= 0 || frequency <= 0)
            throw new XmpBuildException();

        Name = name;
        Timeing = timeing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Name { get; }
    public IList<int> Timeing { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}