using Itmo.ObjectOrientedProgramming.Lab1.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;

public class NoneJumpEngine : IJumpEngine
{
    public EngineFlightResult
        FlightTime(double fuel, double mass, double envLen)
        => new EngineFlightResult(Result.ShipLost, 0, 0);
}