using ConsoleApp1.Parser.Interfaces;

namespace ConsoleApp1.Parser.Implementations;

public class CommandResult : ICommandResult
{
    public CommandResult(string command, IList<string> args)
    {
        Command = command;
        Args = args;
    }

    public string Command { get; }
    public IList<string> Args { get; }
}