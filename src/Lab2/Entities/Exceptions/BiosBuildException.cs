using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class BiosBuildException : Exception
{
    public BiosBuildException(string message)
        : base(message)
    {
    }

    public BiosBuildException()
    {
    }

    public BiosBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}