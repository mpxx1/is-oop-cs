using ConsoleApp1.Parser.Interfaces;

namespace ConsoleApp1.Executor;

public interface ICommandExecutor
{
    public Task Execute(ICommandResult commandResult);
}