using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver.Display;

public class DisplayLogger : ILogger
{
    public DisplayDriver Driver { get; } = new();

    public void PrintMessages(IList<IMessage> messages)
    {
        Driver.ClearConsole();
        string text = string.Empty;

        if (!string.IsNullOrEmpty(Driver.Buf))
        {
            text = Driver.Buf;
        }
        else if (messages != null)
        {
            text = messages[0].Title +
                   '\n' +
                   messages[0].Body;
        }

        System.Console.WriteLine(
            Crayon
                .Output
                .Rgb(Driver.Color.R, Driver.Color.G, Driver.Color.B)
                .Text(text));
    }
}