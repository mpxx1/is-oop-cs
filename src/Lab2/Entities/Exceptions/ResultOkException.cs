using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class ResultOkException : Exception
{
    public ResultOkException(string message)
        : base(message)
    {
    }

    public ResultOkException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ResultOkException()
    {
    }
}