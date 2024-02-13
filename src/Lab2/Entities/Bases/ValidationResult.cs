using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class ValidationResult
{
    public ValidationResult(IList<string> messages, IList<Exception> errors)
    {
        Messages = messages;
        Errors = errors;
    }

    public IList<string> Messages { get; }
    public IList<Exception> Errors { get; }
}