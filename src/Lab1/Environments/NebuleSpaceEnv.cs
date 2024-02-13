using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NebuleSpaceEnv : ISpaceEnv
{
    private readonly Collection<IEnemy>? _enemies;

    public NebuleSpaceEnv(double len, Collection<IEnemy>? enemies = default)
    {
        Len = len;
        _enemies = enemies;
    }

    public Environmant Name { get; } = Environmant.Nebule;
    public double Len { get; }
    public IList<IEnemy>? Enemies
    {
        get { return _enemies?.AsReadOnly(); }
    }

    public EnvAcceptResult Accept(SpaceShip visitor)
    {
        visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));

        return visitor.VisitEnv(this);
    }
}