using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class DirectoryException : Exception
{
    public DirectoryException(string message)
        : base(message)
    {
    }

    public DirectoryException()
    {
    }

    public DirectoryException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}