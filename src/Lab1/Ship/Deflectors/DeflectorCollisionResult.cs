namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;

public class DeflectorCollisionResult
{
    public DeflectorCollisionResult(DeflectorResult result, double damage)
    {
        Result = result;
        Damage = damage;
    }

    public DeflectorResult Result { get; init; }
    public double Damage { get; init; }
}