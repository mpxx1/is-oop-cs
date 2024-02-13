using System;
using Itmo.ObjectOrientedProgramming.Lab1.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;

// Прыжковый двигатель
// Omega – логарифмический (~n log n)
public class OmegaJumpEngine : IJumpEngine
{
    private const double Speed = 3200;
    private const double FuelCounsumption = 3;

    public EngineFlightResult
        FlightTime(double fuel, double mass, double envLen)
    {
        if (envLen > Math.Log2(FuelCounsumption) * fuel)
        {
            return new EngineFlightResult(
                Result.ShipLost,
                0,
                fuel);
        }

        return new EngineFlightResult(
            Result.Success,
            envLen / Speed * mass / 1000,
            fuel - (envLen / Math.Log2(FuelCounsumption)));
    }
}