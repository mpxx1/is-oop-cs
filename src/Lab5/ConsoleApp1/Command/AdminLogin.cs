using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class AdminLogin : ICommand
{
    public string Name => "adminlogin";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        await atmService
            .AdminLogin(args[0], args[1])
            .ConfigureAwait(false);
    }
}