using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class MotherboardShape
{
    public MotherboardShape(string shape)
    {
        if (string.IsNullOrEmpty(shape))
            throw new MotherBoardShapeBuildException();

        Shape = shape;
    }

    public string Shape { get; }
}