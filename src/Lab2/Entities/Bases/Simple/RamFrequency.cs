using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class RamFrequency
{
    public RamFrequency(IList<int> frequencys)
    {
        if (frequencys == null)
            throw new ArgumentNullException(nameof(frequencys));

        if (frequencys.Count.Equals(0))
            throw new RamFrequencyBuildException();

        Frequencys = frequencys;
    }

    public IList<int> Frequencys { get; }
}