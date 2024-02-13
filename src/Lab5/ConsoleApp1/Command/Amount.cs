using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class Amount : ICommand
{
    public string Name => "amount";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        Console.WriteLine(await atmService
            .GetCashAmount()
            .ConfigureAwait(false));
    }
}