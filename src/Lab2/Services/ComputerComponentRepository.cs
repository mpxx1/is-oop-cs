using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bases.Simple;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerComponentRepository
{
    private Repository<Cpu> _cpuRepository;
    private Repository<Motherboard> _motherboardRepository;
    private Repository<Gpu> _gpuRepository;
    private Repository<Ram> _ramRepository;

    private Repository<Cooler> _coolerRepository;
    private Repository<XmpProfile> _xmpProfileRepository;
    private Repository<Ssd> _ssdRepository;
    private Repository<Hdd> _hddRepository;
    private Repository<PcBody> _pcBodyRepository;
    private Repository<PowerUnit> _powerUnitRepository;
    private Repository<WifiUnit> _wifiUnitRepository;

    public ComputerComponentRepository(
        Repository<Cpu> cpuRepository,
        Repository<Motherboard> motherboardRepository,
        Repository<Gpu> gpuRepository,
        Repository<Ram> ramRepository,
        Repository<Cooler> coolerRepository,
        Repository<XmpProfile> xmpProfileRepository,
        Repository<Ssd> ssdRepository,
        Repository<Hdd> hddRepository,
        Repository<PcBody> pcBodyRepository,
        Repository<PowerUnit> powerUnitRepository,
        Repository<WifiUnit> wifiUnitRepository)
    {
        _cpuRepository = cpuRepository;
        _motherboardRepository = motherboardRepository;
        _gpuRepository = gpuRepository;
        _ramRepository = ramRepository;
        _coolerRepository = coolerRepository;
        _xmpProfileRepository = xmpProfileRepository;
        _ssdRepository = ssdRepository;
        _hddRepository = hddRepository;
        _pcBodyRepository = pcBodyRepository;
        _powerUnitRepository = powerUnitRepository;
        _wifiUnitRepository = wifiUnitRepository;
    }

    // cpu
    public Cpu? GetCpuByName(string name)
    {
        return _cpuRepository.GetByName(name);
    }

    public bool RemoveCpuByName(string name)
    {
        return _cpuRepository.Remove(name);
    }

    public bool AddCpu(Cpu cpu)
    {
        return _cpuRepository.Add(cpu);
    }

    // motherboard
    public Motherboard? GetMotherboardByName(string name)
    {
        return _motherboardRepository.GetByName(name);
    }

    public bool RemoveMotherboardByName(string name)
    {
        return _motherboardRepository.Remove(name);
    }

    public bool AddMotherboard(Motherboard motherboard)
    {
        return _motherboardRepository.Add(motherboard);
    }

    // gpu
    public Gpu? GetGpuByName(string name)
    {
        return _gpuRepository.GetByName(name);
    }

    public bool RemoveGpuByName(string name)
    {
        return _gpuRepository.Remove(name);
    }

    public bool AddGpu(Gpu gpu)
    {
        return _gpuRepository.Add(gpu);
    }

    // ram
    public Ram? GetRamByName(string name)
    {
        return _ramRepository.GetByName(name);
    }

    public bool RemoveRamByName(string name)
    {
        return _ramRepository.Remove(name);
    }

    public bool AddRam(Ram ram)
    {
        return _ramRepository.Add(ram);
    }

    // cooler
    public Cooler? GetCoolerByName(string name)
    {
        return _coolerRepository.GetByName(name);
    }

    public bool RemoveCoolerByName(string name)
    {
        return _coolerRepository.Remove(name);
    }

    public bool AddCooler(Cooler cooler)
    {
        return _coolerRepository.Add(cooler);
    }

    // xmp
    public XmpProfile? GetXmpProfileByName(string name)
    {
        return _xmpProfileRepository.GetByName(name);
    }

    public bool RemoveXmpProfileByName(string name)
    {
        return _xmpProfileRepository.Remove(name);
    }

    public bool AddXmpProfile(XmpProfile xmpProfile)
    {
        return _xmpProfileRepository.Add(xmpProfile);
    }

    // ssd
    public Ssd? GetSsdByName(string name)
    {
        return _ssdRepository.GetByName(name);
    }

    public bool RemoveSsdByName(string name)
    {
        return _ssdRepository.Remove(name);
    }

    public bool AddSsd(Ssd ssd)
    {
        return _ssdRepository.Add(ssd);
    }

    // hdd
    public Hdd? GetHddByName(string name)
    {
        return _hddRepository.GetByName(name);
    }

    public bool RemoveHddByName(string name)
    {
        return _hddRepository.Remove(name);
    }

    public bool AddHdd(Hdd hdd)
    {
        return _hddRepository.Add(hdd);
    }

    // body
    public PcBody? GetPcBodyByName(string name)
    {
        return _pcBodyRepository.GetByName(name);
    }

    public bool RemovePcBodyByName(string name)
    {
        return _pcBodyRepository.Remove(name);
    }

    public bool AddPcBody(PcBody pcBody)
    {
        return _pcBodyRepository.Add(pcBody);
    }

    // powerUnit
    public PowerUnit? GetPowerUnitByName(string name)
    {
        return _powerUnitRepository.GetByName(name);
    }

    public bool RemovePowerUnitByName(string name)
    {
        return _powerUnitRepository.Remove(name);
    }

    public bool AddPowerUnit(PowerUnit powerUnit)
    {
        return _powerUnitRepository.Add(powerUnit);
    }

    // wifi
    public WifiUnit? GetWifiUnitByName(string name)
    {
        return _wifiUnitRepository.GetByName(name);
    }

    public bool RemoveWifiUnitByName(string name)
    {
        return _wifiUnitRepository.Remove(name);
    }

    public bool AddWifiUnit(WifiUnit wifiUnit)
    {
        return _wifiUnitRepository.Add(wifiUnit);
    }
}