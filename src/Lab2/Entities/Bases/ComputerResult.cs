using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class ComputerResult
{
    public ComputerResult(Computer? computer, IList<string> messgages, IList<Exception> problems)
    {
        Computer = computer;
        Messages = messgages;
        Problems = problems;
    }

    public Computer? Computer { get; }
    public IList<string> Messages { get; }
    public IList<Exception> Problems { get; }
}