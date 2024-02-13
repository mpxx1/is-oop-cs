using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class GpuBuildException : Exception
{
    public GpuBuildException(string message)
        : base(message)
    {
    }

    public GpuBuildException()
    {
    }

    public GpuBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}