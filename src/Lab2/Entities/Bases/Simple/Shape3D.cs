using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

public class Shape3D
{
    public Shape3D(string name, float length, float width, float height)
    {
        if (length <= 0 || width <= 0 || height <= 0 || string.IsNullOrEmpty(name))
            throw new Shape3DBuildException();

        Length = length;
        Width = width;
        Height = height;
    }

    public float Length { get; }
    public float Width { get; }
    public float Height { get; }
    public string ComponentName()
    {
        return "Shape3D";
    }
}