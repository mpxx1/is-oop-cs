using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class ParserResult : IParserResult
{
    public ParserResult(ConnectionMode connectionMode, string command, IList<string> args)
    {
        Command = command;
        Args = args;
        ConnectionMode = connectionMode;
    }

    public ConnectionMode ConnectionMode { get; }
    public string Command { get; }
    public IList<string> Args { get; }
}