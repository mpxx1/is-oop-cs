using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Command;

public interface ICommand
{
    public string Name { get; }
    public void Exec(IList<string> args, IIOSystem io,  IFileSystem fs);
}