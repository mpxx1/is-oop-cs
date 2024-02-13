using Domain.Model.Interfaces;
using Domain.Ports.Primary;

namespace ConsoleApp1.Command;

public class CreateUser : ICommand
{
    public string Name => "createuser";
    public async Task Execute(IAtmService atmService, IList<string> args)
    {
        if (atmService == null)
            throw new ArgumentNullException(nameof(atmService));

        if (args == null)
            throw new ArgumentNullException(nameof(args));

        IUserResult user = await atmService
            .CreateUser(args[0], args[1])
            .ConfigureAwait(false);

        Console.WriteLine($"User Created:\nBank account: {user.UserAccount}\nPin{user.Pin}");
    }
}