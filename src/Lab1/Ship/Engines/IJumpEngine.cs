namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;

public interface IJumpEngine
{
    public EngineFlightResult
        FlightTime(double fuel, double mass, double envLen);
}