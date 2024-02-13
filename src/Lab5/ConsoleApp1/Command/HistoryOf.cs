using System.Globalization;
using Domain.Model.Interfaces;
using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class HistoryOf : ICommand
{
    public string Name => "histof";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        long acc = long.Parse(args[0], CultureInfo.InvariantCulture);

        IEnumerable<IBankTransaction> history = await atmService
            .HistoryOf(acc)
            .ConfigureAwait(false);

        Console.WriteLine("Account: " + acc);

        foreach (IBankTransaction transaction in history)
        {
            Console.WriteLine(transaction.AtmOperation + " | " +
                              transaction.Amount + " | " +
                              transaction.DateTime);
        }
    }
}