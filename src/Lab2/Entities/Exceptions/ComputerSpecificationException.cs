using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class ComputerSpecificationException : Exception
{
    public ComputerSpecificationException(string message)
        : base(message)
    {
    }

    public ComputerSpecificationException()
    {
    }

    public ComputerSpecificationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}