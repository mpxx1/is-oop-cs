using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CoolerValidator : IComponentValidator
{
    public ValidationResult Validate(Computer computer)
    {
        if (computer == null)
            throw new ComputerValidatorException("Null computer value!");

        var errors = new List<Exception>();
        var messages = new List<string>();

        if (computer.Cooler == null)
        {
            errors.Add(new ComputerBuildException("Cooler is missing"));
            return new ValidationResult(messages, errors);
        }

        if (computer.Cpu != null && computer.Cooler.Tdp < computer.Cpu.Tdp)
            messages.Add("unsuitable cooler, disclaimer of warranty");

        return new ValidationResult(messages, errors);
    }
}