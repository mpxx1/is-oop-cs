using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

namespace Itmo.ObjectOrientedProgramming.Lab1.Runner;

public enum Result
{
    Success,
    ShipLost,
    ShipDestroied,
    CrewDead,
}

public class RunnerResult
{
    public RunnerResult(
        Result result,
        ResultingShip ship,
        double flyTime,
        double flyLength,
        double fuelRemain)
    {
        Result = result;
        Ship = ship;
        FlyLength = flyLength;
        FlyTime = flyTime;
        FuelRemain = fuelRemain;
    }

    public ResultingShip Ship { get; }
    public double FlyTime { get; init; }
    public Result Result { get; }
    public double FlyLength { get; init; }
    public double FuelRemain { get; init; }
}