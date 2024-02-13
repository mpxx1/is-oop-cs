using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class SocketBuildException : Exception
{
    public SocketBuildException(string message)
        : base(message)
    {
    }

    public SocketBuildException()
    {
    }

    public SocketBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}