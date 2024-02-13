using Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Hp;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;

// Прогулочный челнок
// Простой корабль оснащённый импульсным двигателем класса C.
// Не имеет дефлекторов, имеет корпус класса прочности 1 и малые масса-габаритные
// характеристики.
public class Walker : SpaceShip
{
    public Walker(double fuel = 1000, bool photo = false)
        : base(
            1000,
            new DeflectorCls3(photo),
            new CImpEngine(),
            new NoneJumpEngine(),
            new HpLevel1(),
            fuel,
            ResultingShip.Walker)
    {
    }
}