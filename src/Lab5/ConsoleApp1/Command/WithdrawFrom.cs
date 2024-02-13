using System.Globalization;
using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class WithdrawFrom : ICommand
{
    public string Name => "wdfrom";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        long acc = long.Parse(args[0], CultureInfo.InvariantCulture);
        decimal amnt = decimal.Parse(args[1], CultureInfo.InvariantCulture);

        await atmService
            .WithdrawFrom(acc, amnt)
            .ConfigureAwait(false);
    }
}