using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class CoolerBuildException : Exception
{
    public CoolerBuildException(string message)
        : base(message)
    {
    }

    public CoolerBuildException()
    {
    }

    public CoolerBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}