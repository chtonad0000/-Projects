using Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerComponentsFactory
{
    private readonly IFactory<Cpu> _cpuFactory;
    private readonly IFactory<Motherboard> _motherboardFactory;
    private readonly IFactory<Gpu> _gpuFactory;
    private readonly IFactory<Hdd> _hddFactory;
    private readonly IFactory<Ssd> _ssdFactory;
    private readonly IFactory<RamStick> _ramStickFactory;
    private readonly IFactory<PowerBlock> _powerBlockFactory;
    private readonly IFactory<Cooler> _coolerFactory;
    private readonly IFactory<WifiAdapter> _wifiAdapterFactory;
    private readonly IFactory<ComputerCase> _computerCaseFactory;

    public ComputerComponentsFactory(
        IFactory<Cpu> cpuFactory, IFactory<Motherboard> motherboardFactory, IFactory<Gpu> gpuFactory, IFactory<Hdd> hddFactory, IFactory<Ssd> ssdFactory, IFactory<RamStick> ramStickFactory, IFactory<PowerBlock> powerBlockFactory, IFactory<Cooler> coolerFactory, IFactory<WifiAdapter> wifiAdapterFactory, IFactory<ComputerCase> caseFactory)
    {
        _cpuFactory = cpuFactory;
        _motherboardFactory = motherboardFactory;
        _gpuFactory = gpuFactory;
        _hddFactory = hddFactory;
        _ssdFactory = ssdFactory;
        _ramStickFactory = ramStickFactory;
        _powerBlockFactory = powerBlockFactory;
        _coolerFactory = coolerFactory;
        _wifiAdapterFactory = wifiAdapterFactory;
        _computerCaseFactory = caseFactory;
    }

    public Cpu CreateCpuByName(string name)
    {
        return _cpuFactory.CreateByName(name);
    }

    public Motherboard CreateMotherboardByName(string name)
    {
        return _motherboardFactory.CreateByName(name);
    }

    public Gpu CreateGpuByName(string name)
    {
        return _gpuFactory.CreateByName(name);
    }

    public Hdd CreateHddByName(string name)
    {
        return _hddFactory.CreateByName(name);
    }

    public Ssd CreateSsdByName(string name)
    {
        return _ssdFactory.CreateByName(name);
    }

    public RamStick CreateRamStickByName(string name)
    {
        return _ramStickFactory.CreateByName(name);
    }

    public PowerBlock CreatePowerBlockByName(string name)
    {
        return _powerBlockFactory.CreateByName(name);
    }

    public Cooler CreateCoolerByName(string name)
    {
        return _coolerFactory.CreateByName(name);
    }

    public WifiAdapter CreateWifiAdapterByName(string name)
    {
        return _wifiAdapterFactory.CreateByName(name);
    }

    public ComputerCase CreateComputerCaseByName(string name)
    {
        return _computerCaseFactory.CreateByName(name);
    }
}