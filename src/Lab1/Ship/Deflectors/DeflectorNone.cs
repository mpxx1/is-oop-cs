using System;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;

public class DeflectorNone : Deflector
{
    public DeflectorNone(bool photoDeflector)
        : base(0, photoDeflector)
    {
    }

    public override DeflectorCollisionResult Collision(CosmoWhale whale, double shipMass)
    {
        if (whale == null)
            throw new ArgumentNullException(nameof(whale));

        return new DeflectorCollisionResult(DeflectorResult.Destroyed, Convert.ToInt32(
            (whale.Mass * whale.Count / 20.0) - (shipMass * whale.Count / 1000 * 5)));
    }
}