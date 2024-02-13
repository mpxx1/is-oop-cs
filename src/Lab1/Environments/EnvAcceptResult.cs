using Itmo.ObjectOrientedProgramming.Lab1.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class EnvAcceptResult
{
    public EnvAcceptResult(Result result, double time)
    {
        Result = result;
        Time = time;
    }

    public Result Result { get; }
    public double Time { get; }
}