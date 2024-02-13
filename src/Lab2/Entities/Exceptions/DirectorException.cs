using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class DirectorException : Exception
{
    public DirectorException(string message)
        : base(message)
    {
    }

    public DirectorException()
    {
    }

    public DirectorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}