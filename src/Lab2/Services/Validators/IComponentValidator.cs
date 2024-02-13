using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public interface IComponentValidator
{
    public ValidationResult Validate(Computer computer);
}