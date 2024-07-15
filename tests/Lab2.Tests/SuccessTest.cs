using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.DDRTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactorType;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class SuccessTest
{
    private readonly ComputerDirector _computerDirector;
    public SuccessTest()
    {
        var storage = new Storage();
        var cpuBuilder1 = new Cpu.CpuBuilder();
        var cpuBuilder2 = new Cpu.CpuBuilder();
        var cpuBuilder3 = new Cpu.CpuBuilder();
        var motherboardBuilder1 = new Motherboard.MotherboardBuilder();
        var coolerBuilder1 = new Cooler.CoolerBuilder();
        var coolerBuilder2 = new Cooler.CoolerBuilder();
        var gpuBuilder1 = new Gpu.GpuBuilder();
        var gpuBuilder2 = new Gpu.GpuBuilder();
        var ssdBuilder = new Ssd.SsdBuilder();
        var computerCaseBuilder1 = new ComputerCase.ComputerCaseBuilder();
        var ramStickBuilder1 = new RamStick.RamStickBuilder();
        var hddBuilder = new Hdd.HddBuilder();
        var powerBlock1 = new PowerBlock("Aerocool Value Plus 600W", 600);
        storage.AddPowerBlock(powerBlock1);
        var powerBlock2 = new PowerBlock("Aerocool Value Plus 350W", 350);

        storage.AddPowerBlock(powerBlock2);
        cpuBuilder1.SetName("AMD Ryzen 7 5700G")
            .SetSocketType(new Socket("AMD AM4"))
            .SetFrequency(3.8)
            .SetCoreCount(8)
            .SetTdp(117)
            .SetPowerConsumption(65)
            .SetRamFrequencies(3.2);
        storage.AddCpu(cpuBuilder1.Build());
        cpuBuilder2.SetName("Intel Core i5 12400F")
            .SetSocketType(new Socket("Intel LGA 1700"))
            .SetFrequency(2.5)
            .SetCoreCount(6)
            .SetTdp(65)
            .SetPowerConsumption(65)
            .SetRamFrequencies(3.2);
        storage.AddCpu(cpuBuilder2.Build());
        cpuBuilder3.SetName("Intel Core i5 11400F")
            .SetSocketType(new Socket("Intel LGA 1200"))
            .SetFrequency(2.6)
            .SetCoreCount(6)
            .SetTdp(65)
            .SetPowerConsumption(65)
            .SetRamFrequencies(3.2);
        storage.AddCpu(cpuBuilder3.Build());
        motherboardBuilder1.SetName("MSI MPG Z490 GAMING PLUS")
            .SetSocket(new Socket("Intel LGA 1200"))
            .SetBios(new BIOS("Ami", "1.0", new List<Cpu> { cpuBuilder1.Build(), cpuBuilder2.Build(), cpuBuilder3.Build() }))
            .SetChipset(new Chipset("Intel Z490", new List<double> { 4.98, 5.78 }, true))
            .SetDdrType(new DDR4())
            .SetFormFactor(new ATX())
            .SetPcieCount(5)
            .SetSataCount(6)
            .SetRamSticksCount(4);
        storage.AddMotherboard(motherboardBuilder1.Build());
        motherboardBuilder1.SetName("MSI MPG Z490 GAMING PLUS")
            .SetSocket(new Socket("Intel LGA 1200"))
            .SetBios(new BIOS("Ami", "1.0", new List<Cpu> { cpuBuilder1.Build(), cpuBuilder2.Build(), cpuBuilder3.Build() }))
            .SetChipset(new Chipset("Intel Z490", new List<double> { 4.98, 5.78 }, true))
            .SetDdrType(new DDR4())
            .SetFormFactor(new ATX())
            .SetPcieCount(5)
            .SetSataCount(6)
            .SetRamSticksCount(4);
        storage.AddMotherboard(motherboardBuilder1.Build());
        coolerBuilder1.SetName("Deepcool GAMMAXX 300")
            .SetSockets(new Collection<Socket> { new Socket("Intel LGA 1200"), new Socket("Intel LGA 1152") })
            .SetMaxTdp(130)
            .SetHeight(17);
        storage.AddCooler(coolerBuilder1.Build());
        coolerBuilder2.SetName("Thermaltake Engine 17")
            .SetSockets(new Collection<Socket> { new Socket("Intel LGA 1200"), new Socket("Intel LGA 1152") })
            .SetMaxTdp(35)
            .SetHeight(17);
        storage.AddCooler(coolerBuilder2.Build());
        gpuBuilder1.SetName("MSI GeForce RTX 3060 VENTUS 2X")
            .SetChipFrequency(1.807)
            .SetPcieVersion("4.0")
            .SetPowerConsumption(170)
            .SetSize(new Size(235, 124))
            .SetVideoMemory(12);
        storage.AddGpu(gpuBuilder1.Build());
        gpuBuilder2.SetName("Asus GeForce RTX 4080 ROG Strix")
            .SetChipFrequency(2.335)
            .SetPcieVersion("4.0")
            .SetPowerConsumption(320)
            .SetSize(new Size(330, 124))
            .SetVideoMemory(16);
        storage.AddGpu(gpuBuilder2.Build());
        ssdBuilder.SetName("Samsung 970 EVO Plus M.2")
            .SetPcieConnect()
            .SetPowerConsumption(9)
            .SetCapacityGb(500)
            .SetMaxSpeed(3.5);
        storage.AddSsd(ssdBuilder.Build());
        hddBuilder.SetName("Seagate BarraCuda Compute 2.5")
            .SetCapacityGb(1000)
            .SetMaxSpeed(5400)
            .SetPowerConsumption(2);
        storage.AddHdd(hddBuilder.Build());
        computerCaseBuilder1.SetName("Cooler Master CMP 510")
            .SetSize(new Size(463, 204))
            .SetMaxGpuSize(new Size(450, 160))
            .SetMotherboardFormFactors(new Collection<FormFactorType> { new ATX() });
        storage.AddComputerCase(computerCaseBuilder1.Build());
        ramStickBuilder1.SetName("Kingston Fury Beast RGB DDR4 8G")
            .SetCapacityGb(8)
            .SetDdrType(new DDR4())
            .SetMaxFrequency(2.666)
            .SetPowerConsumption(2)
            .SetFormFactor(new DIMM())
            .SetJedec(new Jedec(1.333, 2.666));
        storage.AddRamStick(ramStickBuilder1.Build());

        var cpuFactory = new CpuFactory(storage.CpuList);
        var motherboardFactory = new MotherboardFactory(storage.MotherboardList);
        var coolerFactory = new CoolerFactory(storage.CoolerList);
        var gpuFactory = new GpuFactory(storage.GpuList);
        var hddFactory = new HddFactory(storage.HddList);
        var ssdFactory = new SsdFactory(storage.SsdList);
        var powerBlockFactory = new PowerBlockFactory(storage.PowerBlockList);
        var caseFactory = new ComputerCaseFactory(storage.ComputerCaseList);
        var ramStickFactory = new RamStickFactory(storage.RamStickList);
        var wifiAdapterFactory = new WifiAdapterFactory(storage.WifiAdapterList);
        var computerComponentsFactory = new ComputerComponentsFactory(
            cpuFactory, motherboardFactory, gpuFactory, hddFactory, ssdFactory, ramStickFactory, powerBlockFactory, coolerFactory, wifiAdapterFactory, caseFactory);

        var validators = new Collection<IComputerValidator>
        {
            new CaseValidator(), new CoolerValidator(), new CpuValidator(), new MotherboardValidator(),
            new RamValidator(), new PowerBlockValidator(), new HddOrSsdValidator(),
        };
        var computerBuilder = new ComputerBuilder(validators);
        _computerDirector = new ComputerDirector(computerComponentsFactory, computerBuilder);
    }

    [Fact]
    public void SuccessAssembly()
    {
        GetDefaultDirector();

        Computer result = _computerDirector.Construct();

        Assert.True(result.Warranty);
    }

    private void GetDefaultDirector()
    {
        _computerDirector.SetMotherboard("MSI MPG Z490 GAMING PLUS")
            .SetCpu("Intel Core i5 11400F")
            .SetCooler("Deepcool GAMMAXX 300")
            .SetGpu("MSI GeForce RTX 3060 VENTUS 2X")
            .SetHdd("Seagate BarraCuda Compute 2.5")
            .SetSsd("Samsung 970 EVO Plus M.2")
            .SetPowerBlock("Aerocool Value Plus 600W")
            .SetRamStick("Kingston Fury Beast RGB DDR4 8G")
            .SetRamStick("Kingston Fury Beast RGB DDR4 8G")
            .SetComputerCase("Cooler Master CMP 510");
    }
}