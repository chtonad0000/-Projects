using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Gpu : IComponent<Gpu>
{
    private Gpu(string name, Size size, string pcieVersion, double chipFrequency, int powerConsumption, int videoMemoryGb)
    {
        Name = name;
        Size = size;
        PcieVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        VideoMemoryGb = videoMemoryGb;
    }

    public string Name { get; private set; }
    public Size Size { get; private set; }
    public string PcieVersion { get; private set; }
    public double ChipFrequency { get; private set; }
    public int PowerConsumption { get; private set; }
    public int VideoMemoryGb { get; private set; }

    public Gpu Clone()
    {
        return new Gpu(Name, new Size(Size.Length, Size.Height), PcieVersion, ChipFrequency, PowerConsumption, VideoMemoryGb);
    }

    public class GpuBuilder
    {
        private string? _name;
        private Size? _size;
        private string? _pcieVersion;
        private double _chipFrequency;
        private int _powerConsumption;
        private int _videoMemoryGb;

        public GpuBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public GpuBuilder SetSize(Size size)
        {
            _size = size;

            return this;
        }

        public GpuBuilder SetPcieVersion(string version)
        {
            _pcieVersion = version;

            return this;
        }

        public GpuBuilder SetChipFrequency(double frequency)
        {
            _chipFrequency = frequency;

            return this;
        }

        public GpuBuilder SetPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public GpuBuilder SetVideoMemory(int memory)
        {
            _videoMemoryGb = memory;

            return this;
        }

        public Gpu Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("Name can't be empty", nameof(_name));
            }

            if (_size == null)
            {
                throw new ArgumentNullException(nameof(_size), "Size can't be null");
            }

            if (string.IsNullOrEmpty(_pcieVersion))
            {
                throw new ArgumentException("PcieVersion can't be empty", nameof(_pcieVersion));
            }

            if (_chipFrequency <= 0)
            {
                throw new ArgumentException("Chip frequency must be positive", nameof(_chipFrequency));
            }

            if (_powerConsumption <= 0)
            {
                throw new ArgumentException("Power consumption must be positive", nameof(_powerConsumption));
            }

            if (_videoMemoryGb <= 0)
            {
                throw new ArgumentException("videoMemory consumption must be positive", nameof(_videoMemoryGb));
            }

            return new Gpu(_name, _size, _pcieVersion, _chipFrequency, _powerConsumption, _videoMemoryGb);
        }
    }
}