using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class Motherboard : IHaveName
{
    private Motherboard(string name, CpuSocket socket, PciEVersion pciEVersion, int pciESlotsNumber, int sataPortsNumber, Chipset chipset, Ddr ddr, int ramSlotsNumber, MotherboardShape motherboardShape, Bios bios)
    {
        Name = name;
        Socket = socket;
        PciEVersion = pciEVersion;
        PciESlotsNumber = pciESlotsNumber;
        SataPortsNumber = sataPortsNumber;
        Chipset = chipset;
        Ddr = ddr;
        RamSlotsNumber = ramSlotsNumber;
        MotherboardShape = motherboardShape;
        Bios = bios;
        Name = name;
    }

    public string Name { get; }
    public CpuSocket Socket { get; }
    public PciEVersion PciEVersion { get; }
    public int PciESlotsNumber { get; }
    public int SataPortsNumber { get; }
    public Chipset Chipset { get; }
    public Ddr Ddr { get; }
    public int RamSlotsNumber { get; }
    public MotherboardShape MotherboardShape { get; }
    public Bios Bios { get; }

    public class Builder
    {
        private string _name = string.Empty;
        private CpuSocket? _socket;
        private PciEVersion? _pciEVersion;
        private int _pciESlotsNumber;
        private int _sataPortsNumber;
        private Chipset? _chipset;
        private Ddr? _ddr;
        private int _ramSlotsNumber;
        private MotherboardShape? _motherboardShape;
        private Bios? _bios;
        private Exception? _buildResult;

        public Builder()
        {
        }

        public Builder(Motherboard motherboard)
        {
            if (motherboard == null)
                throw new MotherboardBuildException("can't copy null object");

            _name = motherboard.Name;
            _socket = motherboard.Socket;
            _pciEVersion = motherboard.PciEVersion;
            _pciESlotsNumber = motherboard.PciESlotsNumber;
            _sataPortsNumber = motherboard.SataPortsNumber;
            _chipset = motherboard.Chipset;
            _ddr = motherboard.Ddr;
            _ramSlotsNumber = motherboard.RamSlotsNumber;
            _motherboardShape = motherboard.MotherboardShape;
            _bios = motherboard.Bios;
        }

        public Builder Name(string name)
        {
            if (_buildResult != null)
                return this;

            if (string.IsNullOrEmpty(name))
                _buildResult = new MotherboardBuildException("Wrong Motherboard name");

            _name = name;
            return this;
        }

        public Builder Socket(CpuSocket socket)
        {
            if (_buildResult != null)
                return this;

            _socket = socket;
            return this;
        }

        public Builder PciEVersion(PciEVersion pciEVersion)
        {
            if (_buildResult != null)
                return this;

            _pciEVersion = pciEVersion;
            return this;
        }

        public Builder PciESlots(int pciESlots)
        {
            if (_buildResult != null)
                return this;

            if (pciESlots <= 0)
                _buildResult = new MotherboardBuildException("PciESlotsNumber must be positive");

            _pciESlotsNumber = pciESlots;
            return this;
        }

        public Builder SataPorts(int sataProts)
        {
            if (_buildResult != null)
                return this;

            if (sataProts <= 0)
                _buildResult = new MotherboardBuildException("SataPortsNumber must be positive");

            _sataPortsNumber = sataProts;
            return this;
        }

        public Builder Chipset(Chipset chipset)
        {
            if (_buildResult != null)
                return this;

            _chipset = chipset;
            return this;
        }

        public Builder Ddr(Ddr ddr)
        {
            if (_buildResult != null)
                return this;

            _ddr = ddr;
            return this;
        }

        public Builder RamSlots(int memSlots)
        {
            if (_buildResult != null)
                return this;

            if (memSlots <= 0)
                _buildResult = new MotherboardBuildException("RamSlotsNumber must be positive");

            _ramSlotsNumber = memSlots;
            return this;
        }

        public Builder MotherboardShape(MotherboardShape shape)
        {
            if (_buildResult != null)
                return this;

            _motherboardShape = shape;
            return this;
        }

        public Builder Bios(Bios bios)
        {
            if (_buildResult != null)
                return this;

            _bios = bios;
            return this;
        }

        public Result<Motherboard> Build()
        {
            if (_buildResult != null)
                return new Result<Motherboard>(_buildResult);

            if (_socket == null)
                return new Result<Motherboard>(new MotherboardBuildException("socket must be initialised"));

            if (_pciEVersion == null)
                return new Result<Motherboard>(new MotherboardBuildException("invalid Pci-E version"));

            if (_chipset == null)
                return new Result<Motherboard>(new MotherboardBuildException("chipset must be initialised"));

            if (_ddr == null)
                return new Result<Motherboard>(new MotherboardBuildException("ddr must be initialised"));

            if (_motherboardShape == null)
                return new Result<Motherboard>(new MotherboardBuildException("motherboard must be initialised"));

            if (_bios == null)
                return new Result<Motherboard>(new MotherboardBuildException("bios must be initialised"));

            return new Result<Motherboard>(
                new Motherboard(
                    _name,
                    _socket,
                    _pciEVersion,
                    _pciESlotsNumber,
                    _sataPortsNumber,
                    _chipset,
                    _ddr,
                    _ramSlotsNumber,
                    _motherboardShape,
                    _bios));
        }
    }
}