using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class PowerUnit : IHaveName
{
    public PowerUnit(string name, int maxPowerUse)
    {
        if (maxPowerUse <= 0)
            throw new PowerUnitBuildException();

        Name = name;
        MaxPowerUse = maxPowerUse;
    }

    public string Name { get; }
    public int MaxPowerUse { get; }
}