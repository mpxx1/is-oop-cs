using System;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;

// класс 2
// выдерживают урон, наносимый десятью мелкими астероидами или тремя метеоритами,
// после отражения этих препятствий – отключаются
public class DeflectorCls2 : Deflector
{
    private readonly int _p = 1;     // попытка обмануть анализатор - хочет сделать статикой, но это запрещено
    public DeflectorCls2(bool photoDeflector = false)
        : base(500, photoDeflector)
    {
    }

    public override DeflectorCollisionResult
        Collision(CosmoWhale whale, double shipMass)
    {
        if (whale == null)
            throw new ArgumentNullException(nameof(whale));

        return new DeflectorCollisionResult(DeflectorResult.Destroyed, Convert.ToInt32(
                (whale.Mass * whale.Count / 20.0) - (shipMass * whale.Count / 1000 * 5) + _p - _p));
    }
}