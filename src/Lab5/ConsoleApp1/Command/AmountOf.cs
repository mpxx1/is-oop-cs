using System.Globalization;
using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class AmountOf : ICommand
{
    public string Name => "amtof";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        long acc = long.Parse(args[0], CultureInfo.InvariantCulture);

        Console.WriteLine(
            await atmService
                .GetCashAmountOf(acc)
                .ConfigureAwait(false));
    }
}