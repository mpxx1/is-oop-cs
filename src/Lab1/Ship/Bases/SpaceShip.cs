using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Runner;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Hp;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

public enum ResultingShip
{
    Avgur,
    Walker,
    Stella,
    Meredian,
    Vaclas,
    NoOptimal,
}

public abstract class SpaceShip
{
    private readonly double _mass;
    private readonly Deflector _deflector;
    private readonly IImpEngine _impEngine;
    private readonly IJumpEngine _jumpEngine;
    private readonly HpLevel _hpLevel;

    protected SpaceShip(
        double mass,
        Deflector deflector,
        IImpEngine impEngine,
        IJumpEngine jumpEngine,
        HpLevel hpLevel,
        double fuel,
        ResultingShip name)
    {
        _mass = mass;
        _deflector = deflector;
        _impEngine = impEngine;
        _jumpEngine = jumpEngine;
        _hpLevel = hpLevel;
        Fuel = fuel;
        ShipName = name;
    }

    public ResultingShip ShipName { get; }

    public double Fuel { get; private set; }

    public EnvAcceptResult VisitEnv(ISpaceEnv spaceEnv)
    {
        if (spaceEnv == null)
            throw new ArgumentNullException(nameof(spaceEnv));

        IList<IEnemy> enemies = spaceEnv.Enemies ?? new List<IEnemy>();
        foreach (IEnemy enemy in enemies)
        {
            Result enemyResult = enemy.AcceptShip(this);
            if (!enemyResult.Equals(Result.Success))
            {
                return new EnvAcceptResult(enemyResult, 0);
            }
        }

        EngineFlightResult flightResult;
        flightResult = spaceEnv.Name.Equals(Environmant.Nebule)
            ? _jumpEngine.FlightTime(Fuel, _mass, spaceEnv.Len)
            : _impEngine.FlightTime(Fuel, _mass, spaceEnv.Len);

        Fuel -= flightResult.BurnedFuel;

        return new EnvAcceptResult(flightResult.Result, flightResult.Time);
    }

    public Result VisitEnemy(IEnemy enemy)
    {
        if (enemy is null)
            throw new ArgumentNullException(nameof(enemy));

        DeflectorCollisionResult collisionResult = enemy.AcceptDeflector(_deflector, _mass);

        switch (collisionResult.Result)
        {
            case DeflectorResult.CrewDead:
                return Result.CrewDead;

            case DeflectorResult.Destroyed:
            {
                bool alive = _hpLevel.TakeExtraDamage(Convert.ToInt32(collisionResult.Damage));
                if (!alive) return Result.ShipLost;
                break;
            }
        }

        return Result.Success;
    }
}