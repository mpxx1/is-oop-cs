using Itmo.ObjectOrientedProgramming.Lab1.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;

// Импульсный двигатель класса C
// стандартный импульсный двигатель.
// выдаёт константную скорость средней величины, имеет достаточно низкое потребление топлива (активной плазмы).
public class CImpEngine : IImpEngine
{
    private const double Speed = 3000; // 3 км/с -> скорость для полета от Земли до Марса
    private const double FuelConsumption = 8;

    // расходует 1 единицу топлива на 8 метров полета
    public EngineFlightResult
        FlightTime(double fuel, double mass, double envLen)
    {
        // недостаток топлива
        if (envLen > FuelConsumption * fuel)
        {
            return new EngineFlightResult(
                Result.ShipLost,
                fuel * FuelConsumption / Speed * mass / 1000,
                fuel);
        }

        return new EngineFlightResult(
            Result.Success,
            envLen / Speed * mass / 100,
            fuel - (envLen / FuelConsumption));
    }
}