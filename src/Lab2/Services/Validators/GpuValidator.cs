using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class GpuValidator : IComponentValidator
{
    public ValidationResult Validate(Computer computer)
    {
        if (computer == null)
            throw new ComputerValidatorException("Null computer value!");

        var errors = new List<Exception>();
        var messages = new List<string>();

        if (computer.Cpu != null && !SingleGpu(computer.Cpu, computer.Gpu))
            errors.Add(new ComputerBuildException("Single gpu required"));

        return new ValidationResult(messages, errors);
    }

    private bool SingleGpu(Cpu cpu, Gpu? gpu)
    {
        switch (cpu.InternalGpu)
        {
            case true when gpu == null:
            case false when gpu != null:
                return true;
        }

        return false;
    }
}