using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Command;

public class Rename : ICommand
{
    public string Name => "rename";
    public void Exec(IList<string> args, IIOSystem io, IFileSystem fs)
    {
        if (args == null || args is not { Count: 2 })
            throw new CommandArgumentException();

        if (io == null || fs == null)
            throw new WrongSystemException();

        fs.Rename(args[0], args[1]);
    }
}