using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builder;

public interface IComputerDirector
{
    public IComputerDirector SetMotherboard(string motherboardName);

    public IComputerDirector SetCpu(string cpuName);

    public IComputerDirector SetCooler(string coolerName);

    public IComputerDirector SetGpu(string gpuName);

    public IComputerDirector SetHdd(string hddName);

    public IComputerDirector SetSsd(string ssdName);

    public IComputerDirector SetPowerBlock(string powerBlockName);

    public IComputerDirector SetRamStick(string ramStickName);

    public IComputerDirector SetWifiAdapter(string wifiAdapterName);

    public IComputerDirector SetComputerCase(string caseName);

    public Computer Construct();
}