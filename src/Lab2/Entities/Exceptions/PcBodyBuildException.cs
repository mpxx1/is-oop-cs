using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class PcBodyBuildException : Exception
{
    public PcBodyBuildException(string message)
        : base(message)
    {
    }

    public PcBodyBuildException()
    {
    }

    public PcBodyBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}