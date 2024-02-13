using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class ComputerBuildException : Exception
{
    public ComputerBuildException(string message)
        : base(message)
    {
    }

    public ComputerBuildException()
    {
    }

    public ComputerBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}