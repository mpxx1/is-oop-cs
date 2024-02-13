using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class HardDriveValidator : IComponentValidator
{
    public ValidationResult Validate(Computer computer)
    {
        if (computer == null)
            throw new ComputerValidatorException("Null computer value!");

        var errors = new List<Exception>();

        if (computer.Ssd == null && computer.Hdd == null)
            errors.Add(new ComputerBuildException("Hard Drive is missing"));

        return new ValidationResult(new List<string>(), errors);
    }
}