using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class SsdBuildException : Exception
{
    public SsdBuildException(string message)
        : base(message)
    {
    }

    public SsdBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public SsdBuildException()
    {
    }
}