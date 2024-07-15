using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : IComponent<Ssd>
{
    private Ssd(string name, bool sataConnect, bool pcieConnect, int capacityGb, double maxSpeed, int powerConsumption)
    {
        Name = name;
        SataConnect = sataConnect;
        PcieConnect = pcieConnect;
        CapacityGb = capacityGb;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; private set; }
    public bool SataConnect { get; private set; }
    public bool PcieConnect { get; private set; }
    public int CapacityGb { get; private set; }
    public double MaxSpeed { get; private set; }
    public int PowerConsumption { get; private set; }

    public Ssd Clone()
    {
        return new Ssd(Name, SataConnect, PcieConnect, CapacityGb, MaxSpeed, PowerConsumption);
    }

    public class SsdBuilder
    {
        private string? _name;
        private bool _sataConnect;
        private bool _pcieConnect;
        private int _capacityGb;
        private double _maxSpeed;
        private int _powerConsumption;

        public SsdBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public SsdBuilder SetSataConnect()
        {
            _sataConnect = true;

            return this;
        }

        public SsdBuilder SetPcieConnect()
        {
            _pcieConnect = true;

            return this;
        }

        public SsdBuilder SetCapacityGb(int capacityGb)
        {
            _capacityGb = capacityGb;

            return this;
        }

        public SsdBuilder SetMaxSpeed(double maxSpeed)
        {
            _maxSpeed = maxSpeed;

            return this;
        }

        public SsdBuilder SetPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public Ssd Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("Name can't be empty", nameof(_name));
            }

            if (_capacityGb <= 0)
            {
                throw new ArgumentException("CapacityGb must be positive", nameof(_capacityGb));
            }

            if (_maxSpeed <= 0)
            {
                throw new ArgumentException("MaxSpeed must be positive", nameof(_maxSpeed));
            }

            if (_powerConsumption <= 0)
            {
                throw new ArgumentException("PowerConsumption must be positive", nameof(_powerConsumption));
            }

            return new Ssd(_name, _sataConnect, _pcieConnect, _capacityGb, _maxSpeed, _powerConsumption);
        }
    }
}
