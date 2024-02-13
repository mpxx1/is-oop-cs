using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public enum Environmant
{
    Simple,
    Nebule,
    Nitrino,
}

public interface ISpaceEnv
{
    public IList<IEnemy>? Enemies { get; }
    public double Len { get; }
    public Environmant Name { get; }
    public EnvAcceptResult Accept(SpaceShip visitor);
}