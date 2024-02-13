using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CpuValidator : IComponentValidator
{
    public ValidationResult Validate(Computer computer)
    {
        if (computer == null)
            throw new ComputerValidatorException("Null computer value!");

        var errors = new List<Exception>();
        var messages = new List<string>();

        if (computer.Cpu == null)
            errors.Add(new ComputerBuildException("Cpu field is missing"));

        return new ValidationResult(messages, errors);
    }
}