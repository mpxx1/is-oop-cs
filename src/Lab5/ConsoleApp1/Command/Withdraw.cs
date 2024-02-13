using System.Globalization;
using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class Withdraw : ICommand
{
    public string Name => "withdraw";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        decimal amnt = decimal.Parse(args[0], CultureInfo.InvariantCulture);

        await atmService
            .Withdraw(amnt)
            .ConfigureAwait(false);
    }
}