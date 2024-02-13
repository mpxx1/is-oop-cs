using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Command;

public class Mkdir : ICommand
{
    public string Name => "mkdir";

    public void Exec(IList<string> args, IIOSystem io, IFileSystem fs)
    {
        if (args == null || !args.Count.Equals(1))
            throw new CommandArgumentException();

        if (io == null || fs == null)
            throw new WrongSystemException();

        fs.TouchDir(args[0]);
    }
}