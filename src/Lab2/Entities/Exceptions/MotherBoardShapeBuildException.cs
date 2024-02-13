using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class MotherBoardShapeBuildException : Exception
{
    public MotherBoardShapeBuildException(string message)
        : base(message)
    {
    }

    public MotherBoardShapeBuildException()
    {
    }

    public MotherBoardShapeBuildException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}