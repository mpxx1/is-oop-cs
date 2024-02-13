using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public enum ResultState
{
    Err,
    Ok,
}

public class Result<TR>
{
    private readonly ResultState _state;
    private readonly TR? _value;
    private Exception? _exception;

    public Result(TR value)
    {
        _state = ResultState.Ok;
        _value = value;
        _exception = default;
    }

    public Result(Exception e)
    {
        _state = ResultState.Err;
        _exception = e;
        _value = default;
    }

    public bool IsOk => _state == ResultState.Ok;
    public bool IsErr => !IsOk;

    public TR Ok()
    {
        return _value ?? throw new ResultOkException("Calling Ok() method on Err value");
    }

    public Exception Err()
    {
        return _exception ?? throw new ResultErrException("Calling Err() method on Ok value");
    }
}