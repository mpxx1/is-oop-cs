using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class ComputerValidatorException : Exception
{
    public ComputerValidatorException(string message)
        : base(message)
    {
    }

    public ComputerValidatorException()
    {
    }

    public ComputerValidatorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}