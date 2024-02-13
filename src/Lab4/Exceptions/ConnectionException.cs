using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ConnectionException : Exception
{
    public ConnectionException(string message)
        : base(message)
    {
    }

    public ConnectionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ConnectionException()
    {
    }
}