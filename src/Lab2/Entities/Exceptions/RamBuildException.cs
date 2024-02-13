using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class RamBuildException : Exception
{
    public RamBuildException(string message)
        : base(message)
    {
    }

    public RamBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public RamBuildException()
    {
    }
}