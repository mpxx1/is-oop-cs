using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Command;

public class Touch : ICommand
{
    public string Name => "touch";
    public void Exec(IList<string> args, IIOSystem io, IFileSystem fs)
    {
        if (args == null || args is not { Count: 1 or 2 })
            throw new CommandArgumentException();

        if (io == null || fs == null)
            throw new WrongSystemException();

        string? data = args.Count.Equals(2)
            ? args[1]
            : null;

        fs.TouchFile(args[0], data);
    }
}