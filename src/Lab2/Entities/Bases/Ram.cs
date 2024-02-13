using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;

public class Ram : IHaveName
{
    private Ram(string name, int memSizeGb, JedecVoltPair jedecVoltPair, IList<XmpProfile> xmpProfiles, Ddr ddr, int powerUse)
    {
        Name = name;
        MemSizeGb = memSizeGb;
        JedecVoltPair = jedecVoltPair;
        XmpProfiles = xmpProfiles;
        Ddr = ddr;
        PowerUse = powerUse;
    }

    public string Name { get; }
    public int MemSizeGb { get; }
    public JedecVoltPair JedecVoltPair { get; }
    public IList<XmpProfile> XmpProfiles { get; }
    public Ddr Ddr { get; }
    public int PowerUse { get; }

    public class Builder
    {
        private string _name = string.Empty;
        private int _memSizeGb;
        private JedecVoltPair? _jedecVoltPair;
        private IList<XmpProfile>? _xmpProfiles;
        private Ddr? _ddr;
        private int _powerUse;
        private Exception? _buildException;

        public Builder()
        {
        }

        public Builder(Ram ram)
        {
            if (ram == null)
                throw new RamBuildException();

            _name = ram.Name;
            _jedecVoltPair = ram.JedecVoltPair;
            _powerUse = ram.PowerUse;
            _ddr = ram.Ddr;
            _memSizeGb = ram.MemSizeGb;
            _xmpProfiles = ram.XmpProfiles;
        }

        public Result<Ram> Build()
        {
            if (_buildException != null)
                return new Result<Ram>(_buildException);

            if (string.IsNullOrEmpty(_name))
                return new Result<Ram>(new RamBuildException("Wrong ram name"));

            if (_jedecVoltPair == null)
                return new Result<Ram>(new RamBuildException("Jedec-Voltage pair value can't be null"));

            if (_xmpProfiles == null || _xmpProfiles.Count.Equals(0))
                return new Result<Ram>(new RamBuildException("Wrong xmpProfile list"));

            if (_ddr == null)
                return new Result<Ram>(new RamBuildException("Wrong ddr"));

            return new Result<Ram>(
                new Ram(
                    _name,
                    _memSizeGb,
                    _jedecVoltPair,
                    _xmpProfiles,
                    _ddr,
                    _powerUse));
        }

        public Builder Name(string name)
        {
            if (_buildException != null)
                return this;

            if (string.IsNullOrEmpty(name))
                _buildException = new RamBuildException("Wrong Ram name");

            _name = name;
            return this;
        }

        public Builder JedecVoltage(JedecVoltPair pair)
        {
            if (_buildException != null)
                return this;

            _jedecVoltPair = pair;
            return this;
        }

        public Builder PowerUse(int power)
        {
            if (_buildException != null)
                return this;

            if (power <= 0)
                _buildException = new RamBuildException("Ram power use must be positive");

            _powerUse = power;
            return this;
        }

        public Builder Ddr(Ddr ddr)
        {
            if (_buildException != null)
                return this;

            _ddr = ddr;
            return this;
        }

        public Builder MemSizeGb(int mem)
        {
            if (_buildException != null)
                return this;

            if (mem <= 0)
                _buildException = new RamBuildException("MemSizeGb must be positive");

            _memSizeGb = mem;
            return this;
        }

        public Builder XmpProfiles(IList<XmpProfile> xmpProfiles)
        {
            if (_buildException != null)
                return this;

            if (xmpProfiles == null)
                throw new ArgumentNullException(nameof(xmpProfiles));

            if (xmpProfiles.Count.Equals(0))
                _buildException = new RamBuildException("Wrong XmpProfiles");

            _xmpProfiles = xmpProfiles;
            return this;
        }
    }
}