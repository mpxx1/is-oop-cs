using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class ComputerSpecification
{
    private ComputerSpecification(
        string name,
        string motherboard,
        string cpu,
        string cooler,
        string ram,
        string? xmpProfile,
        string? gpu,
        string? ssd,
        string? hdd,
        string pcBody,
        string powerUnit,
        string? wifiUnit)
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

    public string Motherboard { get; }
    public string Cpu { get; }
    public string Cooler { get; }
    public string Ram { get; }
    public string? XmpProfile { get; }
    public string? Gpu { get; }
    public string? Ssd { get; }
    public string? Hdd { get; }
    public string PcBody { get; }
    public string PowerUnit { get; }
    public string? WifiUnit { get; }

    public class Builder
    {
        private string? _name;
        private string? _motherboard;
        private string? _cpu;
        private string? _cooler;
        private string? _ram;
        private string? _xmpProfile;
        private string? _gpu;
        private string? _ssd;
        private string? _hdd;
        private string? _pcBody;
        private string? _powerUnit;
        private string? _wifiUnit;
        private Exception? _result;

        public Builder() { }

        public Builder(ComputerSpecification spec)
        {
            if (spec == null)
                throw new ComputerSpecificationException();

            _name = spec.Name;
            _motherboard = spec.Motherboard;
            _cpu = spec.Cpu;
            _cooler = spec.Cooler;
            _ram = spec.Ram;
            _xmpProfile = spec.XmpProfile;
            _gpu = spec.Gpu;
            _ssd = spec.Ssd;
            _hdd = spec.Hdd;
            _pcBody = spec.PcBody;
            _powerUnit = spec.PowerUnit;
            _wifiUnit = spec.WifiUnit;
        }

        public Result<ComputerSpecification> Build()
        {
            if (_result != null)
                return new Result<ComputerSpecification>(_result);

            if (_name == null ||
                _motherboard == null ||
                _cooler == null ||
                _cpu == null ||
                _pcBody == null ||
                _powerUnit == null ||
                _ram == null)
                return new Result<ComputerSpecification>(new ComputerSpecificationException("Uninitialised fields"));

            return new Result<ComputerSpecification>(
                new ComputerSpecification(
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
                    _wifiUnit));
        }

        public Builder Name(string name)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(name))
                _result = new ComputerSpecificationException("Wrong name");

            _name = name;
            return this;
        }

        public Builder Motherboard(string motherboard)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(motherboard))
                _result = new ComputerSpecificationException("Wrong motherboard");

            _motherboard = motherboard;
            return this;
        }

        public Builder Cpu(string cpu)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(cpu))
                _result = new ComputerSpecificationException("Wrong CPU");

            _cpu = cpu;
            return this;
        }

        public Builder Cooler(string cooler)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(cooler))
                _result = new ComputerSpecificationException("Wrong cooler");

            _cooler = cooler;
            return this;
        }

        public Builder Ram(string ram)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(ram))
                _result = new ComputerSpecificationException("Wrong RAM");

            _ram = ram;
            return this;
        }

        public Builder XmpProfile(string xmpProfile)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(xmpProfile))
                _result = new ComputerSpecificationException("Wrong XMP profile");

            _xmpProfile = xmpProfile;
            return this;
        }

        public Builder Gpu(string gpu)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(gpu))
                _result = new ComputerSpecificationException("Wrong GPU");

            _gpu = gpu;
            return this;
        }

        public Builder Ssd(string ssd)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(ssd))
                _result = new ComputerSpecificationException("Wrong SSD");

            _ssd = ssd;
            return this;
        }

        public Builder Hdd(string hdd)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(hdd))
                _result = new ComputerSpecificationException("Wrong HDD");

            _hdd = hdd;
            return this;
        }

        public Builder PcBody(string pcBody)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(pcBody))
                _result = new ComputerSpecificationException("Wrong PC body");

            _pcBody = pcBody;
            return this;
        }

        public Builder PowerUnit(string powerUnit)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(powerUnit))
                _result = new ComputerSpecificationException("Wrong power unit");

            _powerUnit = powerUnit;
            return this;
        }

        public Builder WifiUnit(string wifiUnit)
        {
            if (_result != null)
                return this;

            if (string.IsNullOrEmpty(wifiUnit))
                _result = new ComputerSpecificationException("Wrong WiFi unit");

            _wifiUnit = wifiUnit;
            return this;
        }
    }
}