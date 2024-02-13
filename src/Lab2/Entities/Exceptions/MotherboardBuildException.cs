using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class MotherboardBuildException : Exception
{
    public MotherboardBuildException(string message)
        : base(message)
    {
    }

    public MotherboardBuildException()
    {
    }

    public MotherboardBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}