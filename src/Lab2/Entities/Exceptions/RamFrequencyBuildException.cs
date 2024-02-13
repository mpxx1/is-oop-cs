using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class RamFrequencyBuildException : Exception
{
    public RamFrequencyBuildException(string message)
        : base(message)
    {
    }

    public RamFrequencyBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public RamFrequencyBuildException()
    {
    }
}