using System;
using Itmo.ObjectOrientedProgramming.Lab1.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;

// Импульсный двигатель класса E
// импульсный двигатель экспоненциального ускорения. выдаёт скорость,
// экспоненциально растущую на протяжении ускорения корабля данным двигателем.
// такое поведение требует больший расход топлива, чем для двигателя класса C.
public class EImpEngine : IImpEngine
{
    private const double FuelConsumption = 7;
    private double _speed = 3000;

    public EngineFlightResult
        FlightTime(double fuel, double mass, double envLen)
    {
        if (envLen > FuelConsumption * fuel)
        {
            double timeOut = Math.Log(envLen + _speed, Math.E) / mass * 1000;
            return new EngineFlightResult(Result.ShipLost, timeOut, fuel);
        }

        double time = Math.Log(envLen + _speed, Math.E);
        _speed = Math.Exp(time);
        return new EngineFlightResult(Result.Success, time, (fuel - (envLen / FuelConsumption)) / mass * 2300);
    }
}