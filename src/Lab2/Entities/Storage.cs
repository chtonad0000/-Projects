using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Storage
{
    public Collection<Cpu> CpuList { get; private set; } = new();
    public Collection<Motherboard> MotherboardList { get; private set; } = new();
    public Collection<Cooler> CoolerList { get; private set; } = new();
    public Collection<Gpu> GpuList { get; private set; } = new();
    public Collection<Hdd> HddList { get; private set; } = new();
    public Collection<Ssd> SsdList { get; private set; } = new();
    public Collection<PowerBlock> PowerBlockList { get; private set; } = new();
    public Collection<RamStick> RamStickList { get; private set; } = new();
    public Collection<WifiAdapter> WifiAdapterList { get; private set; } = new();
    public Collection<ComputerCase> ComputerCaseList { get; private set; } = new();

    public void AddCpu(Cpu cpu)
    {
        CpuList.Add(cpu);
    }

    public void AddMotherboard(Motherboard motherboard)
    {
        MotherboardList.Add(motherboard);
    }

    public void AddCooler(Cooler cooler)
    {
        CoolerList.Add(cooler);
    }

    public void AddGpu(Gpu gpu)
    {
        GpuList.Add(gpu);
    }

    public void AddHdd(Hdd hdd)
    {
        HddList.Add(hdd);
    }

    public void AddSsd(Ssd ssd)
    {
        SsdList.Add(ssd);
    }

    public void AddPowerBlock(PowerBlock powerBlock)
    {
        PowerBlockList.Add(powerBlock);
    }

    public void AddRamStick(RamStick ramStick)
    {
        RamStickList.Add(ramStick);
    }

    public void AddWifiAdapter(WifiAdapter wifiAdapter)
    {
        WifiAdapterList.Add(wifiAdapter);
    }

    public void AddComputerCase(ComputerCase computerCase)
    {
        ComputerCaseList.Add(computerCase);
    }

    public void DeleteCpu(string cpuName)
    {
        CpuList.Remove(CpuList.FirstOrDefault(cpu => cpu.Name.Equals(cpuName, StringComparison.OrdinalIgnoreCase)) ??
                       throw new InvalidOperationException());
    }

    public void DeleteMotherboard(string motherboardName)
    {
        MotherboardList.Remove(MotherboardList.FirstOrDefault(motherboard => motherboard.Name.Equals(motherboardName, StringComparison.OrdinalIgnoreCase)) ??
                               throw new InvalidOperationException());
    }

    public void DeleteCooler(string coolerName)
    {
        CoolerList.Remove(CoolerList.FirstOrDefault(cooler => cooler.Name.Equals(coolerName, StringComparison.OrdinalIgnoreCase)) ??
                          throw new InvalidOperationException());
    }

    public void DeletedGpu(string gpuName)
    {
        GpuList.Remove(GpuList.FirstOrDefault(gpu => gpu.Name.Equals(gpuName, StringComparison.OrdinalIgnoreCase)) ??
                       throw new InvalidOperationException());
    }

    public void DeleteHdd(string hddName)
    {
        HddList.Remove(HddList.FirstOrDefault(hdd => hdd.Name.Equals(hddName, StringComparison.OrdinalIgnoreCase)) ??
                       throw new InvalidOperationException());
    }

    public void DeleteSsd(string ssdName)
    {
        SsdList.Remove(SsdList.FirstOrDefault(ssd => ssd.Name.Equals(ssdName, StringComparison.OrdinalIgnoreCase)) ??
                       throw new InvalidOperationException());
    }

    public void DeletePowerBlock(string powerBlockName)
    {
        PowerBlockList.Remove(PowerBlockList.FirstOrDefault(powerBlock => powerBlock.Name.Equals(powerBlockName, StringComparison.OrdinalIgnoreCase)) ??
                              throw new InvalidOperationException());
    }

    public void DeleteRamStick(string ramStickName)
    {
        RamStickList.Remove(RamStickList.FirstOrDefault(ramStick => ramStick.Name.Equals(ramStickName, StringComparison.OrdinalIgnoreCase)) ??
                            throw new InvalidOperationException());
    }

    public void DeleteWifiAdapter(string wifiAdapterName)
    {
        WifiAdapterList.Remove(WifiAdapterList.FirstOrDefault(wifiAdapter => wifiAdapter.Name.Equals(wifiAdapterName, StringComparison.OrdinalIgnoreCase)) ??
                               throw new InvalidOperationException());
    }

    public void DeleteComputerCase(string computerCaseName)
    {
        ComputerCaseList.Remove(ComputerCaseList.FirstOrDefault(computerCase => computerCase.Name.Equals(computerCaseName, StringComparison.OrdinalIgnoreCase)) ??
                                throw new InvalidOperationException());
    }

    public void UpdateCpu(Collection<Cpu> cpuList)
    {
        CpuList = cpuList;
    }

    public void UpdateMotherboard(Collection<Motherboard> motherboardList)
    {
        MotherboardList = motherboardList;
    }

    public void UpdateCooler(Collection<Cooler> coolerList)
    {
        CoolerList = coolerList;
    }

    public void UpdateGpu(Collection<Gpu> gpuList)
    {
        GpuList = gpuList;
    }

    public void UpdateHdd(Collection<Hdd> hddList)
    {
        HddList = hddList;
    }

    public void UpdateSsd(Ssd ssd)
    {
        SsdList.Add(ssd);
    }

    public void UpdatePowerBlock(Collection<PowerBlock> powerBlockList)
    {
        PowerBlockList = powerBlockList;
    }

    public void UpdateRamStick(Collection<RamStick> ramStickList)
    {
        RamStickList = ramStickList;
    }

    public void UpdateWifiAdapter(Collection<WifiAdapter> wifiAdapterList)
    {
        WifiAdapterList = wifiAdapterList;
    }

    public void UpdateComputerCase(Collection<ComputerCase> computerCaseList)
    {
        ComputerCaseList = computerCaseList;
    }
}