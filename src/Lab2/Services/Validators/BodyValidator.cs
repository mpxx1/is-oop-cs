using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class BodyValidator : IComponentValidator
{
    public ValidationResult Validate(Computer computer)
    {
        if (computer == null)
            throw new ComputerValidatorException("Null computer value!");

        var errors = new List<Exception>();
        var messages = new List<string>();

        if (computer.PcBody == null)
        {
            errors.Add(new ComputerBuildException("PcBody field is missing"));
            return new ValidationResult(messages, errors);
        }

        if (computer.Gpu != null && !GpuFitIn(computer.PcBody, computer.Gpu))
            errors.Add(new ComputerBuildException("PcBody incompatible with Gpu"));

        if (computer.Motherboard != null && !computer.PcBody.MotherboardShapes.Contains(computer.Motherboard.MotherboardShape))
            errors.Add(new ComputerBuildException("PcBody incompatible with motherboard"));

        return new ValidationResult(messages, errors);
    }

    private bool GpuFitIn(PcBody body, Gpu gpu)
    {
        return gpu.Shape.Height < body.Shape.Height &&
               gpu.Shape.Width < body.Shape.Width &&
               gpu.Shape.Length < body.Shape.Length;
    }
}