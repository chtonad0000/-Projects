using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IComponent<Cpu>
{
    private Cpu(string name, double frequency, int coreCount, Socket socketType, bool graphicCore, double maxRamFrequencies, int tdp, int powerConsumption)
    {
        Name = name;
        Frequency = frequency;
        CoreCount = coreCount;
        SocketType = socketType;
        GraphicCore = graphicCore;
        MaxRamFrequencies = maxRamFrequencies;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; private set; }
    public double Frequency { get; private set; }
    public int CoreCount { get; private set; }
    public Socket SocketType { get; private set; }
    public bool GraphicCore { get; private set; }
    public double MaxRamFrequencies { get; private set; }
    public int Tdp { get; private set; }
    public int PowerConsumption { get; private set; }

    public Cpu Clone()
    {
        return new Cpu(Name, Frequency, CoreCount, new Socket(SocketType.Name), GraphicCore, MaxRamFrequencies, Tdp, PowerConsumption);
    }

    public class CpuBuilder
    {
        private string? _name;
        private double _frequency;
        private int _coreCount;
        private Socket? _socket;
        private bool _graphicCore;
        private double _maxRamFrequency;
        private int _tdp;
        private int _powerConsumption;
        public CpuBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public CpuBuilder SetFrequency(double frequency)
        {
            _frequency = frequency;

            return this;
        }

        public CpuBuilder SetCoreCount(int cores)
        {
            _coreCount = cores;

            return this;
        }

        public CpuBuilder SetSocketType(Socket socketType)
        {
            _socket = socketType;

            return this;
        }

        public CpuBuilder SetGraphicCore()
        {
            _graphicCore = true;

            return this;
        }

        public CpuBuilder SetRamFrequencies(double frequencies)
        {
            _maxRamFrequency = frequencies;

            return this;
        }

        public CpuBuilder SetTdp(int tdp)
        {
            _tdp = tdp;

            return this;
        }

        public CpuBuilder SetPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public Cpu Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("name can't be empty", nameof(_name));
            }

            if (_frequency <= 0)
            {
                throw new ArgumentException("frequency must be positive", nameof(_frequency));
            }

            if (_coreCount <= 0)
            {
                throw new ArgumentException("coresCount must be positive", nameof(_coreCount));
            }

            if (_socket == null || string.IsNullOrEmpty(_socket.Name))
            {
                throw new ArgumentException("invalid socket", nameof(_socket));
            }

            if (_maxRamFrequency <= 0)
            {
                throw new ArgumentException("maxRamFrequency must be positive", nameof(_maxRamFrequency));
            }

            if (_tdp <= 0)
            {
                throw new ArgumentException("tdp must be positive", nameof(_tdp));
            }

            if (_powerConsumption <= 0)
            {
                throw new ArgumentException("powerConsumption must be positive", nameof(_powerConsumption));
            }

            return new Cpu(_name, _frequency, _coreCount, _socket, _graphicCore, _maxRamFrequency, _tdp, _powerConsumption);
        }
    }
}