using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class ChipsetBuildException : Exception
{
    public ChipsetBuildException(string message)
        : base(message)
    {
    }

    public ChipsetBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ChipsetBuildException()
    {
    }
}