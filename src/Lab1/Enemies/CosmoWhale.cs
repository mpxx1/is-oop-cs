using System;
using Itmo.ObjectOrientedProgramming.Lab1.Runner;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Enemies;

public class CosmoWhale : IEnemy
{
    public CosmoWhale(double mass, int count)
    {
        Mass = mass;
        Count = count;
    }

    public double Mass { get; }
    public int Count { get; }

    public Result AcceptShip(SpaceShip visitor)
    {
        if (visitor == null)
            throw new ArgumentNullException(nameof(visitor));

        return visitor.VisitEnemy(this);
    }

    public DeflectorCollisionResult AcceptDeflector(Deflector visitor, double shipMass)
    {
        if (visitor == null)
            throw new ArgumentNullException(nameof(visitor));

        return visitor.Collision(this, shipMass);
    }
}