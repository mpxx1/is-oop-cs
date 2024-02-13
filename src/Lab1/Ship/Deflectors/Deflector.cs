using System;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;

public enum DeflectorResult
{
    Ok,
    Destroyed,
    CrewDead,
}

public abstract class Deflector
{
    private int _hp;
    private int _photo;

    protected Deflector(int hp, bool photo)
    {
        _hp = hp;
        _photo = photo ? 3 : 0;
    }

    public virtual DeflectorCollisionResult Collision(Asteroid asteroid, double shipMass)
    {
        if (asteroid == null)
            throw new ArgumentNullException(nameof(asteroid));

        int damage = Convert.ToInt32((asteroid.Mass * asteroid.Count) +
                                     (shipMass / 250 * 2 * asteroid.Count));
        _hp -= damage;

        return _hp <= 0
            ? new DeflectorCollisionResult(DeflectorResult.Destroyed, -_hp)
            : new DeflectorCollisionResult(DeflectorResult.Ok, 0);
    }

    public DeflectorCollisionResult Collision(AmFlare flare, double shipMass)
    {
        if (flare == null)
            throw new ArgumentNullException(nameof(flare));

        _photo -= flare.Count;

        return _photo <= 0
            ? new DeflectorCollisionResult(DeflectorResult.CrewDead, 0 * shipMass)
            : new DeflectorCollisionResult(DeflectorResult.Ok, 0);
    }

    public virtual DeflectorCollisionResult Collision(CosmoWhale whale, double shipMass)
    {
        if (whale == null)
            throw new ArgumentNullException(nameof(whale));

        return new DeflectorCollisionResult(DeflectorResult.Destroyed, Convert.ToInt32(
                whale.Count == 1
                    ? 0 + _hp - _hp
                    : (whale.Mass * whale.Count / 20.0) - (shipMass * whale.Count / 1000 * 5)));
    }
}