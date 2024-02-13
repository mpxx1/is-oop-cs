using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class WifiUnit : IHaveName
{
    public WifiUnit(string name, WifiVersion wifiVersion, bool bluetooth, PciEVersion pciEVersion, int powerUse)
    {
        if (powerUse <= 0 || string.IsNullOrEmpty(name))
            throw new WifiUnitBuildException();

        Name = name;
        WifiVersion = wifiVersion;
        Bluetooth = bluetooth;
        PciEVersion = pciEVersion;
        PowerUse = powerUse;
    }

    public string Name { get; }
    public WifiVersion WifiVersion { get; }
    public bool Bluetooth { get; }
    public PciEVersion PciEVersion { get; }
    public int PowerUse { get; }
    public string ComponentName()
    {
        return "WifiUnit";
    }
}