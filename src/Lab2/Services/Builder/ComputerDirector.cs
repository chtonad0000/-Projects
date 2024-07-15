using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builder;

public class ComputerDirector : IComputerDirector
{
    private readonly ComputerComponentsFactory _computerComponentsFactory;

    private readonly ComputerBuilder _computerBuilder;

    private string? _motherboardName;
    private string? _cpuName;
    private string? _coolerName;
    private string? _gpuName;
    private string? _hddName;
    private string? _ssdName;
    private string? _powerBlockName;
    private Collection<string>? _ramStickName;
    private string? _caseName;
    private string? _wifiAdapterName;

    public ComputerDirector(ComputerComponentsFactory factory, ComputerBuilder builder)
    {
        _computerComponentsFactory = factory;
        _computerBuilder = builder;
    }

    public IComputerDirector SetMotherboard(string motherboardName)
    {
        _motherboardName = motherboardName;

        return this;
    }

    public IComputerDirector SetCpu(string cpuName)
    {
        _cpuName = cpuName;

        return this;
    }

    public IComputerDirector SetCooler(string coolerName)
    {
        _coolerName = coolerName;

        return this;
    }

    public IComputerDirector SetGpu(string gpuName)
    {
        _gpuName = gpuName;

        return this;
    }

    public IComputerDirector SetHdd(string hddName)
    {
        _hddName = hddName;

        return this;
    }

    public IComputerDirector SetSsd(string ssdName)
    {
        _ssdName = ssdName;

        return this;
    }

    public IComputerDirector SetPowerBlock(string powerBlockName)
    {
        _powerBlockName = powerBlockName;

        return this;
    }

    public IComputerDirector SetRamStick(string ramStickName)
    {
        if (_ramStickName == null)
        {
            _ramStickName = new Collection<string>();
        }

        _ramStickName.Add(ramStickName);

        return this;
    }

    public IComputerDirector SetWifiAdapter(string wifiAdapterName)
    {
        _wifiAdapterName = wifiAdapterName;

        return this;
    }

    public IComputerDirector SetComputerCase(string caseName)
    {
        _caseName = caseName;

        return this;
    }

    public Computer Construct()
    {
        if (!string.IsNullOrEmpty(_motherboardName))
            _computerBuilder.SetMotherboard(_computerComponentsFactory.CreateMotherboardByName(_motherboardName));
        if (!string.IsNullOrEmpty(_cpuName))
            _computerBuilder.SetCpu(_computerComponentsFactory.CreateCpuByName(_cpuName));
        if (!string.IsNullOrEmpty(_coolerName))
            _computerBuilder.SetCooler(_computerComponentsFactory.CreateCoolerByName(_coolerName));
        if (_ramStickName != null)
        {
            foreach (string stick in _ramStickName)
            {
                _computerBuilder.SetRamStick(_computerComponentsFactory.CreateRamStickByName(stick));
            }
        }

        if (!string.IsNullOrEmpty(_ssdName))
            _computerBuilder.SetSsd(_computerComponentsFactory.CreateSsdByName(_ssdName));
        if (!string.IsNullOrEmpty(_hddName))
            _computerBuilder.SetHdd(_computerComponentsFactory.CreateHddByName(_hddName));
        if (!string.IsNullOrEmpty(_wifiAdapterName))
            _computerBuilder.SetWifiAdapter(_computerComponentsFactory.CreateWifiAdapterByName(_wifiAdapterName));
        if (!string.IsNullOrEmpty(_gpuName))
            _computerBuilder.SetGpu(_computerComponentsFactory.CreateGpuByName(_gpuName));
        if (!string.IsNullOrEmpty(_powerBlockName))
            _computerBuilder.SetPowerBlock(_computerComponentsFactory.CreatePowerBlockByName(_powerBlockName));
        if (!string.IsNullOrEmpty(_caseName))
            _computerBuilder.SetComputerCase(_computerComponentsFactory.CreateComputerCaseByName(_caseName));

        return _computerBuilder.Build();
    }

    public Computer Clone()
    {
        return Construct();
    }
}