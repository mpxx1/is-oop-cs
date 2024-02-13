using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class CommandInvoker : ICommandInvoker
{
    private IDictionary<string, ICommand> _commands;
    private IList<IIOSystem> _ioList;
    private IList<IFileSystem> _fsList;

    public CommandInvoker(
        IDictionary<string, ICommand> map,
        IList<IIOSystem> ioList,
        IList<IFileSystem> fsList)
    {
        _commands = map;
        _ioList = ioList;
        _fsList = fsList;
    }

    public string IORead(ConnectionMode connectionMode)
    {
        IIOSystem io = _ioList
                           .FirstOrDefault(x => x.ConnectionMode == connectionMode)
                       ?? throw new WrongSystemException();

        return io.Read();
    }

    public void Execute(IParserResult result)
    {
        if (result == null) return;
        if (result.ConnectionMode == ConnectionMode.Disconnected) return;

        IIOSystem io = _ioList
                           .FirstOrDefault(x => x.ConnectionMode == result.ConnectionMode)
                       ?? throw new WrongSystemException();

        IFileSystem fs = _fsList
                           .FirstOrDefault(x => x.ConnectionMode == result.ConnectionMode)
                       ?? throw new WrongSystemException();

        _commands[result.Command]
            .Exec(result.Args, io, fs);
    }
}