namespace ConsoleApp1.Parser.Interfaces;

public interface ICommandResult
{
    public string Command { get; }
    public IList<string> Args { get; }
}