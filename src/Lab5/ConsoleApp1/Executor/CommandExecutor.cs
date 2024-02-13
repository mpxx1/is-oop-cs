using AtmApi.Exception;
using ConsoleApp1.Command;
using ConsoleApp1.Exceptions;
using ConsoleApp1.LoggerDecorator;
using ConsoleApp1.Parser.Interfaces;
using DbRepositoryImpl.Exceptions;
using Domain.Ports.Primary;

namespace ConsoleApp1.Executor;

public class CommandExecutor : ICommandExecutor
{
    private readonly ILogger _logger;
    private readonly IAtmService _atmService;
    private readonly IEnumerable<ICommand> _commands;

    public CommandExecutor(IEnumerable<ICommand> commands, IAtmService atmService, ILogger logger)
    {
        _commands = commands;
        _atmService = atmService;
        _logger = logger;
    }

    public async Task Execute(ICommandResult commandResult)
    {
        if (commandResult == null)
            throw new NoSuchCommandException("Empty command");

        ICommand command = _commands
                .FirstOrDefault(c => c.Name == commandResult.Command)
            ?? throw new NoSuchCommandException();

        try
        {
            await command.Execute(_atmService, commandResult.Args).ConfigureAwait(false);
        }
        catch (NoSuchUserException e)
        {
            _logger.Log("NoSuchUser\n" + e.Message);
        }
        catch (AuthenticationException e)
        {
            _logger.Log("NoSuchAccount\n" + e.Message);
        }
        catch (InsufficientFundsException e)
        {
            _logger.Log("InsufficientFunds\n" + e.Message);
        }
        catch (NameLengthException e)
        {
            _logger.Log("NameLengthException\n" + e.Message);
        }
        catch (NotPermitedException e)
        {
            _logger.Log("Permission Denied\n" + e.Message);
        }
        catch (PasswdBodyException e)
        {
            _logger.Log("PasswdBodyException\n" + e.Message);
        }
    }
}