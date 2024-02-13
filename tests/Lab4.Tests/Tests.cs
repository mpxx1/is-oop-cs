using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.MemFs;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public static class Tests
{
    private static IDictionary<string, ICommand> _commands = new Dictionary<string, ICommand>
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

    [Fact]
    public static void ConnectTest()
    {
        var parser = new Parser();
        string input = "connect / -m virtual";
        ParserResult result = parser.Parse(input);

        Assert.Equal(ConnectionMode.Virtual, result.ConnectionMode);
        Assert.Equal("tree goto", result.Command);

        input = "disconnect";
        result = parser.Parse(input);

        Assert.Equal(ConnectionMode.Disconnected, result.ConnectionMode);
        Assert.Equal("disconnect", result.Command);
    }

    [Fact]
    public static void MkdirListTest()
    {
        IList<IIOSystem> ioSystems = new List<IIOSystem> { new IOLocal(), new IOVirtual() };
        IList<IFileSystem> fileSystems = new List<IFileSystem> { new LocalFs(), new MemFs() };
        var parser = new Parser();

        var invoker = new CommandInvoker(
            _commands,
            ioSystems,
            fileSystems);
        parser.Parse("connect / -m virtual");

        string input = "mkdir first";
        ParserResult result = parser.Parse(input);

        Assert.Equal("mkdir", result.Command);
        invoker.Execute(result);

        input = "tree list";
        result = parser.Parse(input);

        Assert.Equal("tree list", result.Command);
        invoker.Execute(result);

        Assert.Equal("/ \u23ce\n\tfirst \u23ce\n", invoker.IORead(ConnectionMode.Virtual));
    }

    [Fact]
    public static void CdPwdTest()
    {
        var parser = new Parser();
        IList<IIOSystem> ioSystems = new List<IIOSystem> { new IOLocal(), new IOVirtual() };
        IList<IFileSystem> fileSystems = new List<IFileSystem> { new LocalFs(), new MemFs() };

        var invoker = new CommandInvoker(
            _commands,
            ioSystems,
            fileSystems);
        invoker.Execute(parser.Parse("connect / -m virtual"));

        invoker.Execute(parser.Parse("mkdir first"));
        ParserResult result = parser.Parse("tree goto first");

        Assert.Equal("tree goto", result.Command);
        Assert.Equal("first", result.Args[0]);

        invoker.Execute(result);

        result = parser.Parse("pwd");
        Assert.Equal("pwd", result.Command);

        invoker.Execute(result);
        Assert.Equal("/first", invoker.IORead(ConnectionMode.Virtual));
    }

    [Fact]
    public static void TouchCatTest()
    {
        var parser = new Parser();
        IList<IIOSystem> ioSystems = new List<IIOSystem> { new IOLocal(), new IOVirtual() };
        IList<IFileSystem> fileSystems = new List<IFileSystem> { new LocalFs(), new MemFs() };

        var invoker = new CommandInvoker(
            _commands,
            ioSystems,
            fileSystems);
        ParserResult result = parser.Parse("connect / -m virtual");
        invoker.Execute(result);

        result = parser.Parse("touch hello.txt hello_world");
        Assert.Equal("touch", result.Command);
        invoker.Execute(result);

        result = parser.Parse("file show /hello.txt");
        Assert.Equal("file show", result.Command);
        Assert.Equal("/hello.txt", result.Args[0]);
        invoker.Execute(result);

        Assert.Equal("hello_world", invoker.IORead(ConnectionMode.Virtual));
    }

    [Fact]
    public static void MoveTest()
    {
        var parser = new Parser();
        IList<IIOSystem> ioSystems = new List<IIOSystem> { new IOLocal(), new IOVirtual() };
        IList<IFileSystem> fileSystems = new List<IFileSystem> { new LocalFs(), new MemFs() };

        var invoker = new CommandInvoker(
            _commands,
            ioSystems,
            fileSystems);

        IList<string> instructions = new List<string>
        {
            "connect / -m virtual",
            "mkdir first",
            "mkdir second",
            "tree goto first",
            "touch hello.txt hello_world",
            "file move /first/hello.txt /second",
            "file show /second/hello.txt",
        };

        foreach (string instruction in instructions)
        {
            invoker.Execute(parser.Parse(instruction));
        }

        Assert.Equal("hello_world", invoker.IORead(ConnectionMode.Virtual));
        invoker.Execute(parser.Parse("tree list /first"));
        Assert.Equal("first \u23ce\n", invoker.IORead(ConnectionMode.Virtual));

        invoker.Execute(parser.Parse("disconnect"));
    }

    [Fact]
    public static void CopyTest()
    {
        var parser = new Parser();
        IList<IIOSystem> ioSystems = new List<IIOSystem> { new IOLocal(), new IOVirtual() };
        IList<IFileSystem> fileSystems = new List<IFileSystem> { new LocalFs(), new MemFs() };

        var invoker = new CommandInvoker(
            _commands,
            ioSystems,
            fileSystems);

        IList<string> instructions = new List<string>
        {
            "connect / -m virtual",
            "mkdir first",
            "mkdir second",
            "tree goto first",
            "touch hello.txt hello_world",
            "file copy /first/hello.txt /second",
        };

        foreach (string instruction in instructions)
        {
            invoker.Execute(parser.Parse(instruction));
        }

        invoker.Execute(parser.Parse("file show /first/hello.txt"));
        Assert.Equal("hello_world", invoker.IORead(ConnectionMode.Virtual));
        invoker.Execute(parser.Parse("file show /second/hello.txt"));
        Assert.Equal("hello_world", invoker.IORead(ConnectionMode.Virtual));

        invoker.Execute(parser.Parse("disconnect"));
    }
}