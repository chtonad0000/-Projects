using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : IComponent<Hdd>
{
    private Hdd(string name, int capacityGb, int maxSpeed, int powerConsumption)
    {
        Name = name;
        CapacityGb = capacityGb;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; private set; }
    public int CapacityGb { get; private set; }
    public int MaxSpeed { get; private set; }
    public int PowerConsumption { get; private set; }

    public Hdd Clone()
    {
        return new Hdd(Name, CapacityGb, MaxSpeed, PowerConsumption);
    }

    public class HddBuilder
    {
        private string? _name;
        private int _capacityGb;
        private int _maxSpeed;
        private int _powerConsumption;

        public HddBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public HddBuilder SetCapacityGb(int capacity)
        {
            _capacityGb = capacity;

            return this;
        }

        public HddBuilder SetMaxSpeed(int maxSpeed)
        {
            _maxSpeed = maxSpeed;

            return this;
        }

        public HddBuilder SetPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public Hdd Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("Name can't be empty", nameof(_name));
            }

            if (_capacityGb <= 0)
            {
                throw new ArgumentException("Capacity must be positive", nameof(_capacityGb));
            }

            if (_maxSpeed <= 0)
            {
                throw new ArgumentException("MaxSpeed must be positive", nameof(_maxSpeed));
            }

            if (_powerConsumption <= 0)
            {
                throw new ArgumentException("Power consumption must be positive", nameof(_powerConsumption));
            }

            return new Hdd(_name, _capacityGb, _maxSpeed, _powerConsumption);
        }
    }
}