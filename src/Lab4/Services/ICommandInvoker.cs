using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface ICommandInvoker
{
    public string IORead(ConnectionMode connectionMode);
    public void Execute(IParserResult result);
}