using Itmo.ObjectOrientedProgramming.Lab1.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;

// Прыжковый двигатель
// квадратичный расход
public class GammaJumpEngine : IJumpEngine
{
    private const double Speed = 3500;
    private const double FuelConsumption = 3;

    public EngineFlightResult
        FlightTime(double fuel, double mass, double envLen)
    {
        if (envLen > FuelConsumption * FuelConsumption * fuel)
        {
            return new EngineFlightResult(
                Result.ShipLost,
                0,
                fuel);
        }

        return new EngineFlightResult(
            Result.Success,
            envLen / Speed * mass / 1000,
            fuel - (envLen / FuelConsumption / FuelConsumption));
    }
}