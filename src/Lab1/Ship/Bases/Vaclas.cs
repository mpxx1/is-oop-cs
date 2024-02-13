using Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Hp;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

// Ваклас
// Исследовательский корабль. Оснащён импульсным двигателем класса E и
// прыжковым двигателем класса Gamma, имеет дефлекторы класса 1,
// корпус класса прочности 2 и средние масса-габаритные характеристики.
public class Vaclas : SpaceShip
{
    public Vaclas(double fuel = 1000, bool photo = false)
        : base(
            2000,
            new DeflectorCls1(photo),
            new EImpEngine(),
            new GammaJumpEngine(),
            new HpLevel2(),
            fuel,
            ResultingShip.Vaclas)
    {
    }
}