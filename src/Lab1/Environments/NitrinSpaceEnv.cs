using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NitrinSpaceEnv : ISpaceEnv
{
    private readonly Collection<IEnemy>? _enemies;

    public NitrinSpaceEnv(int len, Collection<IEnemy>? enemies = null)
    {
        Len = len;
        _enemies = enemies;
    }

    public Environmant Name { get; } = Environmant.Nitrino;

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