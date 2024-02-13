using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Display;

public class DisplayDriver : IDisplayDriver
{
    public string Buf { get; set; } = string.Empty;
    public Color Color { get; set; }
    public void ClearConsole()
    {
        Console.Clear();
    }
}