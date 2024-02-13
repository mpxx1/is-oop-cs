using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class PcBody : IHaveName
{
    public PcBody(string name, Shape3D shape, IList<MotherboardShape> motherboardShapes, Shape3D maxGpuShape)
    {
        if (motherboardShapes == null || motherboardShapes.Count.Equals(0) || string.IsNullOrEmpty(name))
            throw new PcBodyBuildException();

        if (shape == null || maxGpuShape == null)
            throw new PcBodyBuildException();

        if (shape.Height < maxGpuShape.Height ||
            shape.Width < maxGpuShape.Width ||
            shape.Length < maxGpuShape.Length)
            throw new PcBodyBuildException();

        Name = name;
        Shape = shape;
        MotherboardShapes = motherboardShapes;
        MaxGpuShape = maxGpuShape;
    }

    public string Name { get; }
    public Shape3D Shape { get; }
    public IList<MotherboardShape> MotherboardShapes { get; }
    public Shape3D MaxGpuShape { get; }
}