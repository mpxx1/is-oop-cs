using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class CommandArgumentException : Exception
{
    public CommandArgumentException(string message)
        : base(message)
    {
    }

    public CommandArgumentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CommandArgumentException()
    {
    }
}