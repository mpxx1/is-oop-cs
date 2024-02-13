using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class Cooler : IHaveName
{
    public Cooler(string name, Shape3D shape, IList<CpuSocket> sockets, int tdp)
    {
        if (sockets == null || sockets.Count.Equals(0) || string.IsNullOrEmpty(name))
            throw new CoolerBuildException();

        Name = name;
        Shape = shape;
        Sockets = sockets;
        Tdp = tdp;
    }

    public string Name { get; }
    public Shape3D Shape { get; }
    public IList<CpuSocket> Sockets { get; }
    public int Tdp { get; }
}