using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class Gpu : IHaveName
{
    private Gpu(string name, Shape3D shape, int memSize, PciEVersion pciEVersion, int frequency, int powerUse)
    {
        Name = name;
        Shape = shape;
        MemSizeGb = memSize;
        PciEVersion = pciEVersion;
        Frequency = frequency;
        PowerUse = powerUse;
    }

    public string Name { get; }
    public Shape3D Shape { get; }
    public int MemSizeGb { get; }
    public PciEVersion PciEVersion { get; }
    public int Frequency { get; }
    public int PowerUse { get; }

    public class Builder
    {
        private string _name = string.Empty;
        private Shape3D? _shape;
        private int _memSize;
        private PciEVersion? _pci;
        private int _frequency;
        private int _power;
        private Exception? _buildException;
        public Builder()
        {
        }

        public Builder(Gpu gpu)
        {
            if (gpu == null)
                throw new GpuBuildException("Wrong gpu");

            _name = gpu.Name;
            _shape = gpu.Shape;
            _pci = gpu.PciEVersion;
            _power = gpu.PowerUse;
            _frequency = gpu.Frequency;
            _memSize = gpu.MemSizeGb;
        }

        public Result<Gpu> Build()
        {
            if (_buildException != null)
                return new Result<Gpu>(_buildException);

            if (string.IsNullOrEmpty(_name))
                return new Result<Gpu>(new GpuBuildException("Not initialized object"));

            if (_shape == null)
                return new Result<Gpu>(new GpuBuildException("Not initialized object"));

            if (_pci == null)
                return new Result<Gpu>(new GpuBuildException("Not initialized object"));

            return new Result<Gpu>(
                new Gpu(
                    _name,
                    _shape,
                    _memSize,
                    _pci,
                    _frequency,
                    _power));
        }

        public Builder Name(string name)
        {
            if (_buildException != null)
                return this;

            if (string.IsNullOrEmpty(name))
                _buildException = new GpuBuildException("Wrong Gpu name");

            _name = name;
            return this;
        }

        public Builder Shape(Shape3D shape)
        {
            if (_buildException != null)
                return this;

            _shape = shape;
            return this;
        }

        public Builder MemSizeGb(int memSize)
        {
            if (_buildException != null)
                return this;

            if (memSize <= 0)
                _buildException = new GpuBuildException("Wrong memory size");

            _memSize = memSize;
            return this;
        }

        public Builder PciEVersion(PciEVersion pci)
        {
            if (_buildException != null)
                return this;

            _pci = pci;
            return this;
        }

        public Builder Frequency(int frequency)
        {
            if (_buildException != null)
                return this;

            if (frequency <= 0)
                _buildException = new GpuBuildException("Frequency must be positive");

            _frequency = frequency;
            return this;
        }

        public Builder PowerUse(int power)
        {
            if (_buildException != null)
                return this;

            if (power <= 0)
                _buildException = new GpuBuildException("PowerUse must be positive");

            _power = power;
            return this;
        }
    }
}