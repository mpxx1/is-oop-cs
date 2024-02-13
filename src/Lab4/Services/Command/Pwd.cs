using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Command;

public class Pwd : ICommand
{
    public string Name => "pwd";
    public void Exec(IList<string> args, IIOSystem io, IFileSystem fs)
    {
        if (io == null || fs == null)
            throw new WrongSystemException();

        io.Write(fs.WorkingDir());
    }
}