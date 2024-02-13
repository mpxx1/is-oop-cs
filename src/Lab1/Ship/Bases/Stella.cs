using Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Hp;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

// Стелла
// Дипломатический корабль. Оснащён импульсным двигателем класса C и
// прыжковым двигателем класса Omega, имеет дефлекторы класса 1,
// корпус класса прочности 1 и малые масса-габаритные характеристики.
public class Stella : SpaceShip
{
    public Stella(double fuel = 1000, bool photo = false)
        : base(
            1000,
            new DeflectorCls1(photo),
            new CImpEngine(),
            new OmegaJumpEngine(),
            new HpLevel1(),
            fuel,
            ResultingShip.Stella)
    {
    }
}