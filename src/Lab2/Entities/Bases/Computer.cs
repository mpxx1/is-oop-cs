using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class Computer
{
    private Computer(string name, Motherboard? motherboard, Cpu? cpu, Cooler? cooler, Ram? ram, XmpProfile? xmpProfile, Gpu? gpu, Ssd? ssd, Hdd? hdd, PcBody? pcBody, PowerUnit? powerUnit, WifiUnit? wifiUnit)
    {
        Name = name;
        Motherboard = motherboard;
        Cpu = cpu;
        Cooler = cooler;
        Ram = ram;
        XmpProfile = xmpProfile;
        Gpu = gpu;
        Ssd = ssd;
        Hdd = hdd;
        PcBody = pcBody;
        PowerUnit = powerUnit;
        WifiUnit = wifiUnit;
    }

    public string Name { get; }
    public Motherboard? Motherboard { get; }
    public Cpu? Cpu { get; }
    public Cooler? Cooler { get; }
    public Ram? Ram { get; }
    public XmpProfile? XmpProfile { get; }
    public Gpu? Gpu { get; }
    public Ssd? Ssd { get; }
    public Hdd? Hdd { get; }
    public PcBody? PcBody { get; }
    public PowerUnit? PowerUnit { get; }
    public WifiUnit? WifiUnit { get; }

    public ComputerBuilder Builder(IEnumerable<IComponentValidator> validators) => new ComputerBuilder(validators);

    public class ComputerBuilder
    {
        private string _name = string.Empty;
        private Motherboard? _motherboard;
        private Cpu? _cpu;
        private Cooler? _cooler;
        private Ram? _ram;
        private XmpProfile? _xmpProfile;
        private Gpu? _gpu;
        private Ssd? _ssd;
        private Hdd? _hdd;
        private PcBody? _pcBody;
        private PowerUnit? _powerUnit;
        private WifiUnit? _wifiUnit;
        private IEnumerable<IComponentValidator>? _validators;

        public ComputerBuilder(IEnumerable<IComponentValidator> validators)
        {
            _validators = validators;
        }

        public ComputerBuilder(Computer computer, IEnumerable<IComponentValidator> validators)
        {
            if (computer == null)
                throw new ComputerValidatorException("Wrong computer for modify");

            _name = computer.Name;
            _motherboard = computer.Motherboard;
            _cpu = computer.Cpu;
            _cooler = computer.Cooler;
            _ram = computer.Ram;
            _xmpProfile = computer.XmpProfile;
            _gpu = computer.Gpu;
            _ssd = computer.Ssd;
            _hdd = computer.Hdd;
            _pcBody = computer.PcBody;
            _powerUnit = computer.PowerUnit;
            _wifiUnit = computer.WifiUnit;

            _validators = validators;
        }

        public ComputerResult Build()
        {
            IList<Exception> errors = new List<Exception>();
            IList<string> messages = new List<string>();

            if (string.IsNullOrEmpty(_name))
            {
                errors.Add(new ComputerValidatorException("NoName computer"));
                return new ComputerResult(null, messages, errors);
            }

            if (_validators == null)
            {
                errors.Add(new ComputerBuildException("Validators list mustn't be empty!"));
                return new ComputerResult(null, messages, errors);
            }

            var tmpComputer = new Computer(
                _name,
                _motherboard,
                _cpu,
                _cooler,
                _ram,
                _xmpProfile,
                _gpu,
                _ssd,
                _hdd,
                _pcBody,
                _powerUnit,
                _wifiUnit);

            foreach (IComponentValidator validator in _validators)
            {
                ValidationResult result = validator.Validate(tmpComputer);

                foreach (Exception error in result.Errors)
                {
                    errors.Add(error);
                }

                foreach (string message in result.Messages)
                {
                    messages.Add(message);
                }
            }

            if (errors.Count.Equals(0))
            {
                return new ComputerResult(
                    tmpComputer,
                    messages,
                    errors);
            }

            return new ComputerResult(null, messages, errors);
        }

        public ComputerBuilder Name(string name)
        {
            _name = name;
            return this;
        }

        public ComputerBuilder Motherboard(Motherboard? motherboard)
        {
            _motherboard = motherboard;
            return this;
        }

        public ComputerBuilder Cpu(Cpu? cpu)
        {
            _cpu = cpu;
            return this;
        }

        public ComputerBuilder Cooler(Cooler? cooler)
        {
            _cooler = cooler;
            return this;
        }

        public ComputerBuilder Ram(Ram? ram)
        {
            _ram = ram;
            return this;
        }

        public ComputerBuilder XmpProfile(XmpProfile? xmpProfile)
        {
            _xmpProfile = xmpProfile;
            return this;
        }

        public ComputerBuilder Gpu(Gpu? gpu)
        {
            _gpu = gpu;
            return this;
        }

        public ComputerBuilder Ssd(Ssd? ssd)
        {
            _ssd = ssd;
            return this;
        }

        public ComputerBuilder Hdd(Hdd? hdd)
        {
            _hdd = hdd;
            return this;
        }

        public ComputerBuilder PcBody(PcBody? pcBody)
        {
            _pcBody = pcBody;
            return this;
        }

        public ComputerBuilder PowerUnit(PowerUnit? powerUnit)
        {
            _powerUnit = powerUnit;
            return this;
        }

        public ComputerBuilder WifiUnit(WifiUnit? wifiUnit)
        {
            _wifiUnit = wifiUnit;
            return this;
        }
    }
}