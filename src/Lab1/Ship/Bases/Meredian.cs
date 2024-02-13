using Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Hp;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

// Мередиан
// Добывающий корабль. Оснащён импульсным двигателем класса E и
// анти-нитринным излучателем, имеет дефлекторы класса 2, корпус класса
// прочности 2 и средние масса-габаритные характеристики.
public class Meredian : SpaceShip
{
    public Meredian(double fuel = 1000, bool photo = false)
        : base(
            2000,
            new DeflectorCls2(photo),
            new EImpEngine(),
            new NoneJumpEngine(),
            new HpLevel2(),
            fuel,
            ResultingShip.Meredian)
    {
    }
}