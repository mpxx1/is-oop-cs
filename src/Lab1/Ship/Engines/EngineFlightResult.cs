using Itmo.ObjectOrientedProgramming.Lab1.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;

public class EngineFlightResult
{
    public EngineFlightResult(Result result, double time, double burnedFuel)
    {
        Result = result;
        Time = time;
        BurnedFuel = burnedFuel;
    }

    public Result Result { get; }
    public double Time { get; }
    public double BurnedFuel { get; }
}