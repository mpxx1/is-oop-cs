using ConsoleApp1.Command;
using ConsoleApp1.Exceptions;
using ConsoleApp1.Executor;
using ConsoleApp1.LoggerDecorator;
using ConsoleApp1.Parser.Implementations;
using ConsoleApp1.Parser.Interfaces;
using DataAccess.Extensions;
using Domain.Ports.Primary;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();

collection
    .AddDataAccess(configuration =>
        {
            configuration.Host = "localhost";
            configuration.Port = 5432;
            configuration.Username = "postgres";
            configuration.Password = "postgres";
            configuration.Database = "postgres";
            configuration.SslMode = "Prefer";
        })
    .AddApiService();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

IList<ICommand> commands = new List<ICommand>
{
    new CreateUser(),
    new CreateAdmin(),
    new UserLogin(),
    new AdminLogin(),
    new Logout(),
    new Amount(),
    new AmountOf(),
    new Withdraw(),
    new WithdrawFrom(),
    new Refill(),
    new RefillTo(),
    new History(),
    new HistoryOf(),
};

scope.UseInfrastructureDataAccess();

ILogger logger = new Logger(Console.Out);
ICommandParser parser = new CommandParser();
ICommandExecutor executor = new CommandExecutor(
    commands,
    provider.GetService<IAtmService>() ?? throw new NotImplementedException(),
    logger);

while (true)
{
    string? input = Console.ReadLine();
    if (input == null) continue;

    ICommandResult commandResult;

    try
    {
        commandResult = parser.Parse(input);
    }
    catch (NoSuchCommandException e)
    {
        logger.Log(e.Message);
        continue;
    }
    catch (WrongCommandUsageException e)
    {
        logger.Log("WrongCommandUsageException\n" + e.Message);
        continue;
    }
    catch (Exception)
    {
        throw;
    }

    await executor.Execute(commandResult).ConfigureAwait(false);
}