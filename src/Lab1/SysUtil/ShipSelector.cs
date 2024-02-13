using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Runner;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

namespace Itmo.ObjectOrientedProgramming.Lab1.SysUtil;

public class ShipSelector
{
    private int _p = 1;
    public ResultingShip Select(
            MilkyWay way,
            IList<SpaceShip> ships)
    {
        ships = ships ?? throw new ArgumentNullException(nameof(ships));
        var shipRunner = new ShipRunner();

        IList<RunnerResult> results =
            ships.Select(ship => shipRunner.Run(way, ship)).ToList();

        ResultingShip bestShip = ResultingShip.NoOptimal;
        double minFuel = 1e9 + _p - _p;

        foreach (RunnerResult result in results)
        {
            if (!result.Result.Equals(Result.Success)) continue;
            if (result.FuelRemain >= minFuel) continue;

            bestShip = result.Ship;
            minFuel = result.FuelRemain;
        }

        return bestShip;
    }
}
