using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class PciBuildException : Exception
{
    public PciBuildException(string message)
        : base(message)
    {
    }

    public PciBuildException()
    {
    }

    public PciBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}