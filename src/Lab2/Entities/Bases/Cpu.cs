using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class Cpu : IHaveName
{
    private Cpu(string name, int coreFrequency, int coresNumber, CpuSocket socket, bool internalGpu, RamFrequency ramFrequency, int tdp, int powerUse)
    {
        Name = name;
        CoreFrequency = coreFrequency;
        CoresNumber = coresNumber;
        Socket = socket;
        InternalGpu = internalGpu;
        RamFrequency = ramFrequency;
        Tdp = tdp;
        PowerUse = powerUse;
    }

    public string Name { get; }
    public int CoreFrequency { get; }
    public int CoresNumber { get; }
    public CpuSocket Socket { get; }
    public bool InternalGpu { get; }
    public RamFrequency RamFrequency { get; }
    public int Tdp { get; }
    public int PowerUse { get; }

    public class Builder
    {
        private string _name = string.Empty;
        private int _coreFrequency;
        private int _coresNumber;
        private CpuSocket? _socket;
        private bool _internalGpu;
        private RamFrequency? _ramFrequency;
        private int _tdp;
        private int _powerUse;
        private Exception? _buildResult;

        public Builder()
        {
        }

        public Builder(Cpu cpu)
        {
            if (cpu == null)
                throw new CpuBuildException("can't copy null object");

            _name = cpu.Name;
            _coreFrequency = cpu.CoreFrequency;
            _coresNumber = cpu.CoresNumber;
            _socket = cpu.Socket;
            _internalGpu = cpu.InternalGpu;
            _ramFrequency = cpu.RamFrequency;
            _tdp = cpu.Tdp;
            _powerUse = cpu.PowerUse;
        }

        public Result<Cpu> Build()
        {
            if (_buildResult != null)
                return new Result<Cpu>(_buildResult);

            if (_ramFrequency == null)
                return new Result<Cpu>(new RamFrequencyBuildException("ramFrequency must be initialised"));

            if (_socket == null)
                return new Result<Cpu>(new SocketBuildException("socket must be initialised"));

            return new Result<Cpu>(
                new Cpu(
                    _name,
                    _coreFrequency,
                    _coresNumber,
                    _socket,
                    _internalGpu,
                    _ramFrequency,
                    _tdp,
                    _powerUse));
        }

        public Builder Name(string name)
        {
            if (_buildResult != null)
                return this;

            if (string.IsNullOrEmpty(name))
                _buildResult = new CpuBuildException("Wrong Cpu name");

            _name = name;
            return this;
        }

        public Builder CoreFrequency(int frequency)
        {
            if (_buildResult != null)
                return this;

            if (frequency <= 0)
                _buildResult = new CpuBuildException("CoreFrequency must be positive");
            else
                _coreFrequency = frequency;

            return this;
        }

        public Builder CoresNumber(int count)
        {
            if (_buildResult != null)
                return this;

            if (count <= 0)
                _buildResult = new CpuBuildException("CoresNumber must be positive");
            else
                _coresNumber = count;

            return this;
        }

        public Builder Socket(CpuSocket socket)
        {
            if (_buildResult != null)
                return this;

            _socket = socket;
            return this;
        }

        public Builder WithGpu()
        {
            if (_buildResult != null)
                return this;

            _internalGpu = true;
            return this;
        }

        public Builder RamFrequency(RamFrequency frequency)
        {
            if (_buildResult != null)
                return this;

            _ramFrequency = frequency;
            return this;
        }

        public Builder Tdp(int tdp)
        {
            if (_buildResult != null)
                return this;

            if (tdp <= 0)
                _buildResult = new CpuBuildException("Tdp must be positive");
            else
                _tdp = tdp;

            return this;
        }

        public Builder PowerUse(int power)
        {
            if (_buildResult != null)
                return this;

            if (power <= 0)
                _buildResult = new CpuBuildException("PowerUse must be postitve");
            else
                _powerUse = power;

            return this;
        }
    }
}