namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;

// класс 3
// выдерживают урон, наносимый 40 мелкими астероидами, десятью метеоритами или
// одним космо-китом, после отражения этих препятствий – отключаются
public class DeflectorCls3 : Deflector
{
    public DeflectorCls3(bool photoDeflector = false)
        : base(1000, photoDeflector)
    {
    }
}