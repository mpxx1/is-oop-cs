using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class PowerUnitValidator : IComponentValidator
{
    public ValidationResult Validate(Computer computer)
    {
        if (computer == null)
            throw new ComputerValidatorException("Null computer value!");

        var errors = new List<Exception>();
        var messages = new List<string>();

        if (computer.PowerUnit == null)
        {
            errors.Add(new ComputerBuildException("PowerUnit field is missing"));
            return new ValidationResult(messages, errors);
        }

        float powerUse = 0;
        if (computer.Cpu != null)
            powerUse += computer.Cpu.PowerUse;

        if (computer.Ram != null)
            powerUse += computer.Ram.PowerUse;

        if (computer.Gpu != null)
            powerUse += computer.Gpu.PowerUse;

        if (computer.Ssd != null)
            powerUse += computer.Ssd.PowerUse;

        if (computer.Hdd != null)
            powerUse += computer.Hdd.PowerUse;

        if (computer.WifiUnit != null)
            powerUse += computer.WifiUnit.PowerUse;

        if (powerUse > computer.PowerUnit.MaxPowerUse)
            messages.Add("unsuitable powerUnit, disclaimer of warranty");

        return new ValidationResult(messages, errors);
    }
}