using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class PowerUnitBuildException : Exception
{
    public PowerUnitBuildException(string message)
        : base(message)
    {
    }

    public PowerUnitBuildException()
    {
    }

    public PowerUnitBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}