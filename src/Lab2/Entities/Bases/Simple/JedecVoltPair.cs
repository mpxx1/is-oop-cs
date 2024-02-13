using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class JedecVoltPair
{
    public JedecVoltPair(int voltage, int frequency)
    {
        if (voltage <= 0 || frequency <= 0)
            throw new JedecVoltBuildException();

        Voltage = voltage;
        Frequency = frequency;
    }

    public int Voltage { get; }
    public int Frequency { get; }
}