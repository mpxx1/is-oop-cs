using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class WrongSystemException : Exception
{
    public WrongSystemException(string message)
        : base(message)
    {
    }

    public WrongSystemException()
    {
    }

    public WrongSystemException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}