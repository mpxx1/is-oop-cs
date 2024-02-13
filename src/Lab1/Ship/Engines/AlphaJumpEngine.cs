using Itmo.ObjectOrientedProgramming.Lab1.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;

// Прыжковый двигатель
// Alpha – линейный расход
public class AlphaJumpEngine : IJumpEngine
{
    private const double Speed = 3000;
    private const double FuelConsumption = 5;

    public EngineFlightResult
        FlightTime(double fuel, double mass, double envLen)
    {
        if (envLen > FuelConsumption * fuel)
        {
            return new EngineFlightResult(
                Result.ShipLost,
                0,
                fuel);
        }

        return new EngineFlightResult(
            Result.Success,
            envLen / Speed * mass / 1000,
            fuel - (envLen / FuelConsumption));
    }
}