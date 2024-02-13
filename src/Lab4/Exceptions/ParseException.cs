using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ParseException : Exception
{
    public ParseException(string message)
        : base(message)
    {
    }

    public ParseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ParseException()
    {
    }
}