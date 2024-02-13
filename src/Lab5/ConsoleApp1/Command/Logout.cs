using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class Logout : ICommand
{
    public string Name => "logout";
    public Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        atmService.Logout();

        return Task.CompletedTask;
    }
}