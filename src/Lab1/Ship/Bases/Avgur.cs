using Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Hp;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

// Авгур
// Боевой корабль. Оснащён импульсным двигателем класса E и
// прыжковым двигателем класса Alpha, имеет дефлекторы класса 3,
// корпус класса прочности 3 и большие масса-габаритные характеристики.
public class Avgur : SpaceShip
{
    public Avgur(double fuel = 1000, bool photo = false)
        : base(
            4000,
            new DeflectorCls3(photo),
            new EImpEngine(),
            new AlphaJumpEngine(),
            new HpLevel3(),
            fuel,
            ResultingShip.Avgur)
    {
    }
}