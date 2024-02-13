using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class DdrBuildException : Exception
{
    public DdrBuildException(string message)
        : base(message)
    {
    }

    public DdrBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DdrBuildException()
    {
    }
}