namespace Itmo.ObjectOrientedProgramming.Lab1.FuelChange;

public class Fuel
{
    private readonly double _num = 10;
    public double BuyFuel(double cost) => cost / _num;
}