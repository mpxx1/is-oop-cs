using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class WifiUnitBuildException : Exception
{
    public WifiUnitBuildException(string message)
        : base(message)
    {
    }

    public WifiUnitBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WifiUnitBuildException()
    {
    }
}