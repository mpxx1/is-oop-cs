using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class ResultErrException : Exception
{
    public ResultErrException(string message)
        : base(message)
    {
    }

    public ResultErrException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ResultErrException()
    {
    }
}