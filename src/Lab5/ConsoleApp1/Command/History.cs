using Domain.Model.Interfaces;
using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class History : ICommand
{
    public string Name => "history";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        IEnumerable<IBankTransaction> history = await atmService
            .History()
            .ConfigureAwait(false);

        foreach (IBankTransaction transaction in history)
        {
            Console.WriteLine(transaction.AtmOperation + " | " +
                              transaction.Amount + " | " +
                              transaction.DateTime);
        }
    }
}