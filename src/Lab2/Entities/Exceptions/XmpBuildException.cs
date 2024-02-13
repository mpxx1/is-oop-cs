using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class XmpBuildException : Exception
{
    public XmpBuildException(string message)
        : base(message)
    {
    }

    public XmpBuildException()
    {
    }

    public XmpBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}