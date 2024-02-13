using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Command;

public class Remove : ICommand
{
    public string Name => "remove";
    public void Exec(IList<string> args, IIOSystem io, IFileSystem fs)
    {
        if (args == null || args is not { Count: 1 })
            throw new CommandArgumentException();

        if (io == null || fs == null)
            throw new WrongSystemException();

        fs.Remove(args[0]);
    }
}