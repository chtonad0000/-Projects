using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builder;

public class ComputerBuilder : IComputerBuilder
{
    private readonly Collection<IComputerValidator> _validators;
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private Cooler? _cooler;
    private Gpu? _gpu;
    private Hdd? _hdd;
    private Ssd? _ssd;
    private PowerBlock? _powerBlock;
    private Collection<RamStick>? _ramStick;
    private WifiAdapter? _wifiAdapter;
    private ComputerCase? _computerCase;

    public ComputerBuilder(Collection<IComputerValidator> validators)
    {
        _validators = validators;
    }

    public IComputerBuilder SetMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;

        return this;
    }

    public IComputerBuilder SetCpu(Cpu cpu)
    {
        _cpu = cpu;

        return this;
    }

    public IComputerBuilder SetCooler(Cooler cooler)
    {
        _cooler = cooler;

        return this;
    }

    public IComputerBuilder SetGpu(Gpu gpu)
    {
        _gpu = gpu;

        return this;
    }

    public IComputerBuilder SetHdd(Hdd hdd)
    {
        _hdd = hdd;

        return this;
    }

    public IComputerBuilder SetSsd(Ssd ssd)
    {
        _ssd = ssd;

        return this;
    }

    public IComputerBuilder SetPowerBlock(PowerBlock powerBlock)
    {
        _powerBlock = powerBlock;

        return this;
    }

    public IComputerBuilder SetRamStick(RamStick ramStick)
    {
        if (_ramStick == null)
        {
            _ramStick = new Collection<RamStick>();
        }

        _ramStick.Add(ramStick);

        return this;
    }

    public IComputerBuilder SetWifiAdapter(WifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;

        return this;
    }

    public IComputerBuilder SetComputerCase(ComputerCase computerCase)
    {
        _computerCase = computerCase;

        return this;
    }

    public Computer Build()
    {
        if (_motherboard == null)
        {
            throw new ArgumentException("motherboard can't be null", nameof(_motherboard));
        }

        if (_cpu == null)
        {
            throw new ArgumentException("cpu can't be null", nameof(_cpu));
        }

        if (_cooler == null)
        {
            throw new ArgumentException("cooler can't be null", nameof(_cooler));
        }

        if (_ramStick == null)
        {
            throw new ArgumentException("ramStick can't be null", nameof(_ramStick));
        }

        if (_powerBlock == null)
        {
            throw new ArgumentException("powerBlock can't be null", nameof(_powerBlock));
        }

        if (_computerCase == null)
        {
            throw new ArgumentException("computerCase can't be null", nameof(_computerCase));
        }

        var computer = new Computer(_motherboard, _cpu, _cooler, _ramStick, _computerCase, _powerBlock)
        {
            GpuAdapter = _gpu,
            Hdd = _hdd,
            Ssd = _ssd,
            WifiAdapter = _wifiAdapter,
        };

        foreach (IComputerValidator validator in _validators)
        {
            validator.Valid(computer);
        }

        return computer;
    }
}