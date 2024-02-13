using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class Hdd : IHaveName
{
    public Hdd(string name, int capacityGb, int rotationSpeed, int powerUse)
    {
        if (capacityGb <= 0 || rotationSpeed <= 0 || powerUse <= 0 || string.IsNullOrEmpty(name))
            throw new HddBuildException();

        Name = name;
        CapacityGb = capacityGb;
        RotationSpeed = rotationSpeed;
        PowerUse = powerUse;
    }

    public string Name { get; }
    public int CapacityGb { get; }
    public int RotationSpeed { get; }
    public int PowerUse { get; }
}