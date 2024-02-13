using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class CreateAdmin : ICommand
{
    public string Name => "createadmin";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        await atmService
            .CreateAdmin(args[0], args[1], args[2], args[3])
            .ConfigureAwait(false);
    }
}