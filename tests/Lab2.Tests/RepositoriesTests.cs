using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public static class RepositoriesTests
{
    private static readonly IList<Cpu> CpuList = new List<Cpu>
    {
        new Cpu
                .Builder()
            .Name("IntelTest")
            .CoresNumber(4)
            .Socket(new CpuSocket("AB-123"))
            .RamFrequency(new RamFrequency(new List<int> { 2020, 3040 }))
            .CoreFrequency(2020)
            .Tdp(10)
            .PowerUse(150)
            .Build()
            .Ok(),

        new Cpu
                .Builder()
            .Name("AmdTest")
            .CoresNumber(24)
            .Socket(new CpuSocket("AB-123"))
            .RamFrequency(new RamFrequency(new List<int> { 2020, 3040 }))
            .CoreFrequency(4020)
            .WithGpu()
            .Tdp(100)
            .PowerUse(150)
            .Build()
            .Ok(),
    };

    private static readonly IList<Shape3D> Shape = new List<Shape3D>
    {
        new Shape3D("shap", 10, 20, 30),
        new Shape3D("shap", 100, 200, 300),
    };

    private static readonly IList<Gpu> GpuList = new List<Gpu>
    {
        new Gpu
                .Builder()
            .Name("Nvidia 3090 Ti")
            .PowerUse(100)
            .Frequency(3020)
            .Shape(Shape[0])
            .PciEVersion(new PciEVersion("1.20.3"))
            .MemSizeGb(10)
            .Build()
            .Ok(),

        new Gpu
                .Builder()
            .Name("Amd Test 1.1")
            .PowerUse(120)
            .Frequency(2020)
            .Shape(Shape[0])
            .PciEVersion(new PciEVersion("TestPci 1.4.3"))
            .MemSizeGb(10)
            .Build()
            .Ok(),
    };

    private static readonly IList<XmpProfile> Xmp = new List<XmpProfile>
    {
        new XmpProfile("xmpTest1", new List<int> { 18, 18, 36, 48 }, 30, 2020),
        new XmpProfile("xmpTest2", new List<int> { 18, 18, 36, 48 }, 40, 4030),
    };

    private static readonly IList<Ram> Ram = new List<Ram>
    {
        new Ram
                .Builder()
            .Name("KingstonTest")
            .MemSizeGb(16)
            .Ddr(new Ddr("DDR4-DIMM"))
            .PowerUse(10)
            .JedecVoltage(new JedecVoltPair(30, 2020))
            .XmpProfiles(Xmp)
            .Build()
            .Ok(),
    };

    private static readonly IList<MotherboardShape> Shapes = new List<MotherboardShape>
    {
        new MotherboardShape("G44"),
        new MotherboardShape("F-5648"),
        new MotherboardShape("HYPER-V4"),
    };

    private static readonly IList<Ddr> Ddrs = new List<Ddr>
    {
        new Ddr("DDR4"),
        new Ddr("DDR4 DIMM"),
        new Ddr("DDR5"),
    };

    private static readonly IList<Bios> Bios = new List<Bios>
    {
        new Bios(BiosType.Uefi, "Asus GFX", "v1.45.32", new List<string>
        {
            "IntelTest",
            "IntelTest2",
            "AmdRyzan5",
        }),
        new Bios(BiosType.Bios, "GIGABYTE GFX", "v2.40.0", new List<string>
        {
            "IntelTest3",
            "IntelTestBF",
            "AmdRyzan5",
        }),
    };

    private static readonly IList<CpuSocket> Sockets = new List<CpuSocket>
    {
        new CpuSocket("FX 334"),
        new CpuSocket("GR 33"),
        new CpuSocket("AS 4332"),
    };

    private static readonly IList<Chipset> Chipsets = new List<Chipset>
    {
        new Chipset("chip1", new List<int> { 2020, 4040, }, false),
        new Chipset("chip2", new List<int> { 2050, 3040, }, true),
        new Chipset("chip3", new List<int> { 2020, 5200, }, false),
        new Chipset("chip4", new List<int> { 3020, 4040, 5440 }, true),
    };

    private static readonly IList<Motherboard> BoardList = new List<Motherboard>
    {
        new Motherboard
                .Builder()
            .Name("Asus Test")
            .Socket(new CpuSocket("AB-123"))
            .Chipset(Chipsets[0])
            .PciEVersion(new PciEVersion("1.20.3"))
            .PciESlots(4)
            .RamSlots(4)
            .SataPorts(4)
            .MotherboardShape(Shapes[2])
            .Ddr(Ddrs[1])
            .Bios(Bios[0])
            .Build()
            .Ok(),

        new Motherboard
                .Builder()
            .Name("Asus2 Test")
            .Socket(new CpuSocket("AB-123"))
            .Chipset(Chipsets[0])
            .PciEVersion(new PciEVersion("1.20.3"))
            .PciESlots(4)
            .RamSlots(4)
            .SataPorts(4)
            .MotherboardShape(Shapes[2])
            .Ddr(Ddrs[1])
            .Bios(Bios[0])
            .Build()
            .Ok(),
    };

    private static readonly IList<Cooler> Coolers = new List<Cooler>
    {
        new Cooler("cooler1", new Shape3D("shap", 10, 20, 20), new List<CpuSocket>() { Sockets[0], Sockets[1] }, 100),
        new Cooler("cooler2", new Shape3D("shap", 10, 20, 20), new List<CpuSocket>() { Sockets[0], Sockets[1] }, 10),
    };

    private static readonly IList<PcBody> PcBodies = new List<PcBody>
    {
        new PcBody("body1", new Shape3D("shap", 100, 100, 100), Shapes, new Shape3D("shap", 40, 40, 40)),
    };

    private static readonly IList<Ssd> Ssds = new List<Ssd>
    {
        new Ssd("Kingston test", SsdConnector.Sata, 1000, 600, 600),
    };

    private static readonly IList<Hdd> Hdds = new List<Hdd>
    {
        new Hdd("Intel test hdd", 2000, 400, 30),
    };

    private static readonly IList<WifiUnit> WifiUnits = new List<WifiUnit>
    {
        new WifiUnit("wifi00", new WifiVersion("6e"), true, new PciEVersion("1.1.2"), 20),
    };

    private static readonly IList<PowerUnit> PowerUnits = new List<PowerUnit>
    {
        new PowerUnit("PowerTest", 1000),
    };

    private static readonly IEnumerable<IComponentValidator> Validators = new List<IComponentValidator>()
    {
        new MotherBoardValidator(),
        new CpuValidator(),
        new BodyValidator(),
        new CoolerValidator(),
        new RamValidator(),
        new GpuValidator(),
        new HardDriveValidator(),
        new PowerUnitValidator(),
    };

    private static readonly ComputerComponentRepository Repo = new ComputerComponentRepository(
        new Repository<Cpu>(CpuList),
        new Repository<Motherboard>(BoardList),
        new Repository<Gpu>(GpuList),
        new Repository<Ram>(Ram),
        new Repository<Cooler>(Coolers),
        new Repository<XmpProfile>(Xmp),
        new Repository<Ssd>(Ssds),
        new Repository<Hdd>(Hdds),
        new Repository<PcBody>(PcBodies),
        new Repository<PowerUnit>(PowerUnits),
        new Repository<WifiUnit>(WifiUnits));

    [Fact]
    public static void ComputerBuildTest()
    {
        ComputerSpecification spec = new ComputerSpecification
                .Builder()
            .Name("testName")
            .Motherboard("Asus2 Test")
            .Cpu("IntelTest")
            .Cooler("cooler1")
            .Ram("KingstonTest")
            .Gpu("Nvidia 3090 Ti")
            .Ssd("Kingston test")
            .Hdd("Intel test hdd")
            .PcBody("body1")
            .PowerUnit("PowerTest")
            .WifiUnit("wifi00")
            .Build()
            .Ok();

        var director = new ComputerDirector();

        ComputerResult comp = director.CreateComputer(new Computer.ComputerBuilder(Validators), spec, Repo);

        Assert.Equal("testName", comp.Computer?.Name);
    }

    [Fact]
    public static void UpdateRepoTest()
    {
        var repo = new ComputerComponentRepository(
            new Repository<Cpu>(CpuList),
            new Repository<Motherboard>(BoardList),
            new Repository<Gpu>(GpuList),
            new Repository<Ram>(Ram),
            new Repository<Cooler>(Coolers),
            new Repository<XmpProfile>(Xmp),
            new Repository<Ssd>(Ssds),
            new Repository<Hdd>(Hdds),
            new Repository<PcBody>(PcBodies),
            new Repository<PowerUnit>(PowerUnits),
            new Repository<WifiUnit>(WifiUnits));

        repo.AddSsd(new Ssd("Inter Ssd 1", SsdConnector.PciE, 2048, 1000, 10));
        Assert.Equal(2048, repo.GetSsdByName("Inter Ssd 1")?.CapacityGb);
    }

    [Fact]
    public static void RemoveRepoTest()
    {
        var repo = new ComputerComponentRepository(
            new Repository<Cpu>(CpuList),
            new Repository<Motherboard>(BoardList),
            new Repository<Gpu>(GpuList),
            new Repository<Ram>(Ram),
            new Repository<Cooler>(Coolers),
            new Repository<XmpProfile>(Xmp),
            new Repository<Ssd>(Ssds),
            new Repository<Hdd>(Hdds),
            new Repository<PcBody>(PcBodies),
            new Repository<PowerUnit>(PowerUnits),
            new Repository<WifiUnit>(WifiUnits));

        repo.AddSsd(new Ssd("Inter Ssd 1", SsdConnector.PciE, 2048, 1000, 10));
        repo.RemoveSsdByName("Inter Ssd 1");
        Assert.Null(repo.GetSsdByName("Inter Ssd 1"));
    }
}