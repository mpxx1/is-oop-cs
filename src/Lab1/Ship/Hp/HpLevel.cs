namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Hp;

public abstract class HpLevel
{
    private int _hp;

    protected HpLevel(int hp)
    {
        _hp = hp;
    }

    public bool TakeExtraDamage(int extraDamage)
    {
        _hp -= extraDamage;
        return _hp > 0;
    }
}