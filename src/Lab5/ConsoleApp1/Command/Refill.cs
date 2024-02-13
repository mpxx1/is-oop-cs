using System.Globalization;
using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class Refill : ICommand
{
    public string Name => "refill";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        decimal amnt = decimal.Parse(args[0], CultureInfo.InvariantCulture);

        await atmService
            .Refill(amnt)
            .ConfigureAwait(false);
    }
}