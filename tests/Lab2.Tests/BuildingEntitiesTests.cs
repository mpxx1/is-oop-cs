using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public static class BuildingEntitiesTests
{
    private static readonly IList<Result<Cpu>> CpuList = new List<Result<Cpu>>
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
            .Build(),

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
            .Build(),
    };

    private static readonly IList<Shape3D> Shape = new List<Shape3D>
    {
        new Shape3D("shap", 10, 20, 30),
        new Shape3D("shap", 100, 200, 300),
    };

    private static readonly IList<Result<Gpu>> GpuList = new List<Result<Gpu>>
    {
        new Gpu
                .Builder()
            .Name("Nvidia 3090 Ti")
            .PowerUse(100)
            .Frequency(3020)
            .Shape(Shape[0])
            .PciEVersion(new PciEVersion("TestPci 1.2.0"))
            .MemSizeGb(10)
            .Build(),

        new Gpu
                .Builder()
            .Name("Amd Test 1.1")
            .PowerUse(120)
            .Frequency(2020)
            .Shape(Shape[0])
            .PciEVersion(new PciEVersion("TestPci 1.4.3"))
            .MemSizeGb(10)
            .Build(),
    };

    private static readonly IList<XmpProfile> Xmp = new List<XmpProfile>
    {
        new XmpProfile("xmpTest1", new List<int> { 18, 18, 36, 48 }, 30, 2020),
        new XmpProfile("xmpTest2", new List<int> { 18, 18, 36, 48 }, 40, 4030),
    };

    private static readonly IList<Result<Ram>> Ram = new List<Result<Ram>>
    {
        new Ram
                .Builder()
            .Name("KingstonTest")
            .MemSizeGb(16)
            .Ddr(new Ddr("DDR4-DIMM"))
            .PowerUse(10)
            .JedecVoltage(new JedecVoltPair(30, 2020))
            .XmpProfiles(Xmp)
            .Build(),
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

    private static readonly IList<Chipset> Chipsets = new List<Chipset>
    {
        new Chipset("chip1", new List<int> { 2020, 4040, }, false),
        new Chipset("chip2", new List<int> { 2050, 3040, }, true),
        new Chipset("chip3", new List<int> { 2020, 5200, }, false),
        new Chipset("chip4", new List<int> { 3020, 4040, 5440 }, true),
    };

    private static readonly IList<Result<Motherboard>> BoardList = new List<Result<Motherboard>>()
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
            .Build(),

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
            .Build(),
    };

    [Fact]
    public static void CpuBuildTest()
    {
        Cpu cpu = CpuList[0].Ok();
        Assert.Equal("IntelTest", cpu.Name);
    }

    [Fact]
    public static void CpuRebuildTest()
    {
        Result<Cpu> cpu = new Cpu
                .Builder(CpuList[0].Ok())
            .Name("AmdTest")
            .Build();

        Assert.Equal("AmdTest", cpu.Ok().Name);
    }

    [Fact]
    public static void MotherboardBuildTest()
    {
        Motherboard motherboard = BoardList[0].Ok();
        Assert.Equal("Asus Test", motherboard.Name);
    }

    [Fact]
    public static void MotherboardRebuildTest()
    {
        Result<Motherboard> motherboard = new Motherboard
                .Builder(BoardList[0].Ok())
            .Bios(Bios[0])
            .Build();

        Assert.Equal(Bios[0], motherboard.Ok().Bios);
    }

    [Fact]
    public static void GpuBuildTest()
    {
        Gpu gpu = GpuList[0].Ok();
        Assert.Equal("Nvidia 3090 Ti", gpu.Name);
    }

    [Fact]
    public static void GpuRebuildTest()
    {
        Result<Gpu> gpu = new Gpu
                .Builder(GpuList[1].Ok())
            .MemSizeGb(20)
            .Build();

        Assert.Equal(20, gpu.Ok().MemSizeGb);
    }

    [Fact]
    public static void RamBuildTest()
    {
        Ram ram = Ram[0].Ok();
        Assert.Equal("KingstonTest", ram.Name);
    }

    [Fact]
    public static void RamRebuildTest()
    {
        Result<Ram> ram = new Ram
                .Builder(Ram[0].Ok())
            .MemSizeGb(64)
            .Build();

        Assert.Equal(64, ram.Ok().MemSizeGb);
    }
}