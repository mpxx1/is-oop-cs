using System;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;

// класс 1
// выдерживают урон, наносимый двумя мелкими астероидами или одним метеоритом,
// после отражения этих препятствий – отключаются
public class DeflectorCls1 : Deflector
{
    public DeflectorCls1(bool photoDeflector = false)
        : base(100, photoDeflector)
    {
    }

    public override DeflectorCollisionResult
        Collision(CosmoWhale whale, double shipMass)
    {
        if (whale == null)
            throw new ArgumentNullException(nameof(whale));

        return new DeflectorCollisionResult(DeflectorResult.Destroyed, 1 << 16);
    }
}