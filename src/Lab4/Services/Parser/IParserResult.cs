using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public interface IParserResult
{
    public string Command { get; }
    public ConnectionMode ConnectionMode { get; }
    public IList<string> Args { get; }
}