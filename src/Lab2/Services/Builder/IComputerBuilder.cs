using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builder;

public interface IComputerBuilder
{
    public IComputerBuilder SetMotherboard(Motherboard motherboard);

    public IComputerBuilder SetCpu(Cpu cpu);

    public IComputerBuilder SetCooler(Cooler cooler);

    public IComputerBuilder SetGpu(Gpu gpu);

    public IComputerBuilder SetHdd(Hdd hdd);

    public IComputerBuilder SetSsd(Ssd ssd);

    public IComputerBuilder SetPowerBlock(PowerBlock powerBlock);

    public IComputerBuilder SetRamStick(RamStick ramStick);

    public IComputerBuilder SetWifiAdapter(WifiAdapter wifiAdapter);

    public IComputerBuilder SetComputerCase(ComputerCase computerCase);

    public Computer Build();
}