using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public interface ICommand
{
    public string Name { get; }
    public Task Execute(IAtmService atmService, IList<string> args);
}