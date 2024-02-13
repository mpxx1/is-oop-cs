using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class JedecVoltBuildException : Exception
{
    public JedecVoltBuildException(string message)
        : base(message)
    {
    }

    public JedecVoltBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public JedecVoltBuildException()
    {
    }
}