using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class Shape3DBuildException : Exception
{
    public Shape3DBuildException(string message)
        : base(message)
    {
    }

    public Shape3DBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public Shape3DBuildException()
    {
    }
}