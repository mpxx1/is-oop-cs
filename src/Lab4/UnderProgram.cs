using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.MemFs;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class UnderProgram
{
    private IDictionary<string, ICommand> _commands = new Dictionary<string, ICommand>
    {
        { "file show", new Concat() },
        { "tree goto", new Cd() },
        { "file copy", new Copy() },
        { "tree list", new List() },
        { "mkdir", new Mkdir() },
        { "file move", new Move() },
        { "pwd", new Pwd() },
        { "file delete", new Remove() },
        { "file rename", new Rename() },
        { "touch", new Touch() },
    };

    private Parser _parser = new Parser();
    private IList<IIOSystem> _ioSystems = new List<IIOSystem> { new IOLocal(), new IOVirtual() };
    private IList<IFileSystem> _fileSystems = new List<IFileSystem> { new LocalFs(), new MemFs() };

    public void Run()
    {
        var invoker = new CommandInvoker(
            _commands,
            _ioSystems,
            _fileSystems);

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            invoker.Execute(_parser.Parse(input));
        }
    }
}