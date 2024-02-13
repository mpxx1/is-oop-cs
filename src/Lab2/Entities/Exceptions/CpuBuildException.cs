using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class CpuBuildException : Exception
{
    public CpuBuildException(string message)
        : base(message)
    {
    }

    public CpuBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CpuBuildException()
    {
    }
}