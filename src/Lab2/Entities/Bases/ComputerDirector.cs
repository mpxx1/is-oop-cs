using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class ComputerDirector
{
    private Computer.ComputerBuilder? _builder;

    public ComputerDirector()
    {
    }

    public ComputerResult CreateComputer(
        Computer.ComputerBuilder? builder,
        ComputerSpecification? specification,
        ComputerComponentRepository repository)
    {
        if (builder == null ||
            specification == null ||
            repository == null)
            throw new DirectorException("Arguments can't have null value");

        _builder = builder;

        _builder
            .Name(specification.Name)
            .Motherboard(repository.GetMotherboardByName(specification.Motherboard))
            .Cooler(repository.GetCoolerByName(specification.Cooler))
            .Cpu(repository.GetCpuByName(specification.Cpu))
            .Ram(repository.GetRamByName(specification.Ram))
            .PowerUnit(repository.GetPowerUnitByName(specification.PowerUnit))
            .PcBody(repository.GetPcBodyByName(specification.PcBody));

        if (specification.XmpProfile != null)
            _builder.XmpProfile(repository.GetXmpProfileByName(specification.XmpProfile));

        if (specification.WifiUnit != null)
            _builder.WifiUnit(repository.GetWifiUnitByName(specification.WifiUnit));

        if (specification.Ssd != null)
            _builder.Ssd(repository.GetSsdByName(specification.Ssd));

        if (specification.Hdd != null)
            _builder.Hdd(repository.GetHddByName(specification.Hdd));

        if (specification.Gpu != null)
            _builder.Gpu(repository.GetGpuByName(specification.Gpu));

        return _builder.Build();
    }
}