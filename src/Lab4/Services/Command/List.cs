using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Command;

public class List : ICommand
{
    public string Name => "list";

    public void Exec(IList<string> args, IIOSystem io, IFileSystem fs)
    {
        if (args == null)
            throw new CommandArgumentException();

        if (io == null || fs == null)
            throw new WrongSystemException();

        if (args.Count > 3 || args.Count < 0)
            throw new CommandArgumentException();

        int depth = 0;
        switch (args.Count)
        {
            case 3:
            {
                if (args[1] != "-d")
                    throw new CommandArgumentException();
                bool suc = int.TryParse(args[2], out depth);
                if (!suc)
                    throw new CommandArgumentException();

                break;
            }

            case 2:
            {
                if (args[0] != "-d")
                    throw new CommandArgumentException();
                bool suc = int.TryParse(args[1], out depth);
                if (!suc)
                    throw new CommandArgumentException();

                break;
            }
        }

        string? path = args.Count % 2 == 0
            ? null
            : args[0];

        io.Write(fs.List(path, depth));
    }
}