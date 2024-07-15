using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.DDRTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactorType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class RamStick : IComponent<RamStick>
{
    private RamStick(string name, int capacityGb, Jedec jedec, Collection<Xmp>? xmpProfiles, FormFactorType formFactor, DDRType ddrType, int powerConsumption, double maxFrequency)
    {
        Name = name;
        CapacityGb = capacityGb;
        Jedec = jedec;
        XmpProfiles = xmpProfiles;
        FromFactor = formFactor;
        DdrType = ddrType;
        PowerConsumption = powerConsumption;
        MaxFrequency = maxFrequency;
    }

    public string Name { get; private set; }
    public int CapacityGb { get; private set; }
    public Jedec Jedec { get; private set; }
    public Collection<Xmp>? XmpProfiles { get; private set; }
    public FormFactorType FromFactor { get; private set; }
    public DDRType DdrType { get; private set; }
    public int PowerConsumption { get; private set; }
    public double MaxFrequency { get; private set; }

    public void UpdateXmpProfiles(Collection<Xmp> profiles)
    {
        XmpProfiles = profiles;
    }

    public RamStick Clone()
    {
        return new RamStick(Name, CapacityGb, new Jedec(Jedec.FirstFreq, Jedec.SecondFreq), XmpProfiles, FromFactor, DdrType, PowerConsumption, MaxFrequency);
    }

    public class RamStickBuilder
    {
        private string? _name;
        private int _capacityGb;
        private Jedec? _jedec;
        private Collection<Xmp>? _xmpProfiles;
        private FormFactorType? _formFactor;
        private DDRType? _ddrType;
        private int _powerConsumption;
        private double _maxFrequency;

        public RamStickBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public RamStickBuilder SetCapacityGb(int capacityGb)
        {
            _capacityGb = capacityGb;

            return this;
        }

        public RamStickBuilder SetJedec(Jedec jedec)
        {
            _jedec = jedec;

            return this;
        }

        public RamStickBuilder SetXmpProfiles(Collection<Xmp> xmpProfiles)
        {
            _xmpProfiles = xmpProfiles;

            return this;
        }

        public RamStickBuilder SetFormFactor(FormFactorType formFactor)
        {
            _formFactor = formFactor;

            return this;
        }

        public RamStickBuilder SetDdrType(DDRType ddrType)
        {
            _ddrType = ddrType;

            return this;
        }

        public RamStickBuilder SetPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public RamStickBuilder SetMaxFrequency(double maxFrequency)
        {
            _maxFrequency = maxFrequency;

            return this;
        }

        public RamStick Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("Name can't be empty", nameof(_name));
            }

            if (_capacityGb <= 0)
            {
                throw new ArgumentException("CapacityGb must be positive", nameof(_capacityGb));
            }

            if (_jedec == null)
            {
                throw new ArgumentNullException(nameof(_jedec), "Jedec can't be null");
            }

            if (_formFactor == null)
            {
                throw new ArgumentNullException(nameof(_formFactor), "FormFactor can't be null");
            }

            if (_ddrType == null)
            {
                throw new ArgumentNullException(nameof(_ddrType), "DDRType can't be null");
            }

            if (_powerConsumption <= 0)
            {
                throw new ArgumentException("PowerConsumption must be positive", nameof(_powerConsumption));
            }

            if (_maxFrequency <= 0)
            {
                throw new ArgumentException("MaxFrequency must be positive", nameof(_maxFrequency));
            }

            return new RamStick(_name, _capacityGb, _jedec, _xmpProfiles, _formFactor, _ddrType, _powerConsumption, _maxFrequency);
        }
    }
}
