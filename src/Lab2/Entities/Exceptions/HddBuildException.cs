using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class HddBuildException : Exception
{
    public HddBuildException(string message)
        : base(message)
    {
    }

    public HddBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public HddBuildException()
    {
    }
}