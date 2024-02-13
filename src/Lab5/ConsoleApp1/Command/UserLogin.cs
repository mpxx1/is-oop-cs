using System.Globalization;
using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class UserLogin : ICommand
{
    public string Name => "login";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        long acc = long.Parse(args[0], CultureInfo.InvariantCulture);
        short pin = short.Parse(args[1], CultureInfo.InvariantCulture);

        await atmService
            .UserLogin(acc, pin)
            .ConfigureAwait(false);
    }
}