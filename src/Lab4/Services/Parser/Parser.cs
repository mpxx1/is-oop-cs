using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class Parser
{
    public Parser()
    {
        ConnectionMode = Entities.ConnectionMode.Disconnected;
    }

    private ConnectionMode ConnectionMode { get; set; }
    public ParserResult Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ParseException("Invalid input");

        string[] words = input.Split(' ');
        IList<string> args = new List<string>();
        int i = 2;

        if (words[0].Equals("connect", StringComparison.Ordinal))
        {
            if (words[2].Equals("-m", StringComparison.Ordinal))
            {
                ConnectionMode = words[3] switch
                {
                    "local" => ConnectionMode.Local,
                    "virtual" => ConnectionMode.Virtual,
                    _ => throw new ConnectionException(),
                };
            }

            return new(ConnectionMode, "tree goto", new List<string> { words[1] });
        }

        if (words[0].Equals("disconnect", StringComparison.Ordinal))
        {
            ConnectionMode = ConnectionMode.Disconnected;
        }
        else if (words[0].Equals("tree", StringComparison.Ordinal))
        {
            words[0] = words[1] switch
            {
                "goto" => "tree goto",
                "list" => "tree list",
                _ => throw new CommandArgumentException(),
            };
        }
        else if (words[0].Equals("file", StringComparison.Ordinal))
        {
            words[0] = words[1] switch
            {
                "show" => "file show",
                "move" => "file move",
                "copy" => "file copy",
                "delete" => "file remove",
                "rename" => "file rename",
                _ => throw new CommandArgumentException(),
            };
        }
        else
        {
            i = 1;
        }

        for (; i < words.Length; ++i)
        {
            args.Add(words[i]);
        }

        return new(ConnectionMode, words[0], args);
    }
}