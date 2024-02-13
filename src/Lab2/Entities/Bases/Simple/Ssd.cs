using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public enum SsdConnector
{
    PciE,
    Sata,
}

public class Ssd : IHaveName
{
    public Ssd(string name, SsdConnector connector, int capacityGb, int speed, int powerUse)
    {
        if (capacityGb <= 0 || speed <= 0 || powerUse <= 0 || string.IsNullOrEmpty(name))
            throw new SsdBuildException();

        Name = name;
        Connector = connector;
        CapacityGb = capacityGb;
        Speed = speed;
        PowerUse = powerUse;
    }

    public string Name { get; }
    public SsdConnector Connector { get; }
    public int CapacityGb { get; }
    public int Speed { get; }
    public int PowerUse { get; }
    public string ComponentName()
    {
        return "Ssd";
    }
}