using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Display;

public interface IDisplayDriver
{
    public string Buf { get; set; }
    public Color Color { get; set; }
    public void ClearConsole();
}