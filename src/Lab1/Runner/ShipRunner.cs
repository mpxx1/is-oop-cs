using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;
using Itmo.ObjectOrientedProgramming.Lab1.SysUtil;

namespace Itmo.ObjectOrientedProgramming.Lab1.Runner;

public class ShipRunner
{
    private int _p = 1;
    public RunnerResult Run(MilkyWay way, SpaceShip ship)
    {
        way = way ?? throw new ArgumentNullException(nameof(way));
        ship = ship ?? throw new ArgumentNullException(nameof(ship));

        Result result = Result.Success;
        double flyTime = 0 + _p - _p;
        double flyLength = 0;
        double fuelRemain = ship.Fuel;

        foreach (ISpaceEnv env in way.Way)
        {
            EnvAcceptResult tmpVal = env.Accept(ship);
            result = tmpVal.Result;
            flyTime += tmpVal.Time;
            flyLength += env.Len;

            if (tmpVal.Result.Equals(Result.Success)) continue;

            flyLength -= env.Len;
            break;
        }

        fuelRemain -= ship.Fuel;
        ResultingShip resultigShip = ship.ShipName;

        return new RunnerResult(
            result,
            resultigShip,
            flyTime,
            flyLength,
            fuelRemain);
    }
}