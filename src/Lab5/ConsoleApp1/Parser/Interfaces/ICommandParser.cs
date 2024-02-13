namespace ConsoleApp1.Parser.Interfaces;

public interface ICommandParser
{
    public ICommandResult Parse(string input);
}