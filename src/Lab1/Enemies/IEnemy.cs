using Itmo.ObjectOrientedProgramming.Lab1.Runner;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Enemies;

public interface IEnemy
{
    public double Mass { get; }
    public int Count { get; }
    public Result AcceptShip(SpaceShip visitor);
    public DeflectorCollisionResult AcceptDeflector(Deflector visitor, double shipMass);
}