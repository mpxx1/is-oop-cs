using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class MotherBoardValidator : IComponentValidator
{
    public ValidationResult Validate(Computer computer)
    {
        if (computer == null)
            throw new ComputerValidatorException("Null computer value!");

        var errors = new List<Exception>();
        var messages = new List<string>();

        if (computer.Motherboard == null)
        {
            errors.Add(new ComputerBuildException("Motherboard field is missing"));
            return new ValidationResult(messages, errors);
        }

        if (computer.Cpu != null && computer.Motherboard.Socket.Name != computer.Cpu.Socket.Name)
            errors.Add(new ComputerBuildException("Difference between cpu and motherboard sockets"));

        if (computer.Cpu != null &&
            !computer.Motherboard.Bios.SupportedChips.Contains(computer.Cpu.Name))
            errors.Add(new ComputerBuildException("Motherboard doesn't support cpu"));

        if (computer.Gpu != null &&
            computer.Gpu.PciEVersion.Version != computer.Motherboard.PciEVersion.Version)
            errors.Add(new ComputerBuildException("gpu and motherboard pci version difference"));

        return new ValidationResult(messages, errors);
    }
}