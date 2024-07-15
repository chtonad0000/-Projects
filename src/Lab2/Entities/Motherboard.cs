using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.DDRTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactorType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : IComponent<Motherboard>
{
    private Motherboard(string name, Socket socket, int pcieCount, int sataCount, Chipset chipset, DDRType ddrType, int ramSticksCount, FormFactorType formFactor, BIOS bios, bool hasWifiAdapter)
    {
        Name = name;
        Socket = socket;
        PcieCount = pcieCount;
        SataCount = sataCount;
        Chipset = chipset;
        DdrType = ddrType;
        RamSticksCount = ramSticksCount;
        FormFactor = formFactor;
        Bios = bios;
        HasWifiAdapter = hasWifiAdapter;
    }

    public string Name { get; private set; }
    public Socket Socket { get; private set; }
    public int PcieCount { get; private set; }
    public int SataCount { get; private set; }
    public Chipset Chipset { get; private set; }
    public DDRType DdrType { get; private set; }
    public int RamSticksCount { get; private set; }
    public FormFactorType FormFactor { get; private set; }
    public BIOS Bios { get; private set; }
    public bool HasWifiAdapter { get; private set; }

    public void UpdateBios(BIOS bios)
    {
        Bios = bios;
    }

    public Motherboard Clone()
    {
        return new Motherboard(
            Name, new Socket(Socket.Name), PcieCount, SataCount, new Chipset(Chipset.Name, Chipset.AvailableFrequency, Chipset.HasXmp), DdrType, RamSticksCount, FormFactor, new BIOS(Bios.Type, Bios.Version, Bios.SupportedCpus), HasWifiAdapter);
    }

    public class MotherboardBuilder
    {
        private string? _name;
        private Socket? _socket;
        private int _pcieCount;
        private int _sataCount;
        private Chipset? _chipset;
        private DDRType? _ddrType;
        private int _ramSticksCount;
        private FormFactorType? _formFactor;
        private BIOS? _bios;
        private bool _hasWifiAdapter;

        public MotherboardBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public MotherboardBuilder SetSocket(Socket socket)
        {
            _socket = socket;

            return this;
        }

        public MotherboardBuilder SetPcieCount(int pcieCount)
        {
            _pcieCount = pcieCount;

            return this;
        }

        public MotherboardBuilder SetSataCount(int sataCount)
        {
            _sataCount = sataCount;

            return this;
        }

        public MotherboardBuilder SetChipset(Chipset chipset)
        {
            _chipset = chipset;

            return this;
        }

        public MotherboardBuilder SetDdrType(DDRType ddrType)
        {
            _ddrType = ddrType;

            return this;
        }

        public MotherboardBuilder SetRamSticksCount(int ramSticksCount)
        {
            _ramSticksCount = ramSticksCount;

            return this;
        }

        public MotherboardBuilder SetFormFactor(FormFactorType formFactor)
        {
            _formFactor = formFactor;

            return this;
        }

        public MotherboardBuilder SetBios(BIOS bios)
        {
            _bios = bios;

            return this;
        }

        public MotherboardBuilder SetWifiAdapter(bool hasWifiAdapter)
        {
            _hasWifiAdapter = hasWifiAdapter;

            return this;
        }

        public Motherboard Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("Name can't be empty", nameof(_name));
            }

            if (_socket == null)
            {
                throw new ArgumentNullException(nameof(_socket), "Socket can't be null");
            }

            if (_chipset == null)
            {
                throw new ArgumentNullException(nameof(_chipset), "Chipset can't be null");
            }

            if (_ddrType == null)
            {
                throw new ArgumentNullException(nameof(_ddrType), "DdrType can't be null");
            }

            if (_formFactor == null)
            {
                throw new ArgumentNullException(nameof(_formFactor), "FormFactor can't be null");
            }

            if (_pcieCount <= 0)
            {
                throw new ArgumentException("PcieCount must be positive", nameof(_pcieCount));
            }

            if (_sataCount <= 0)
            {
                throw new ArgumentException("SataCount must be positive", nameof(_sataCount));
            }

            if (_ramSticksCount <= 0)
            {
                throw new ArgumentException("RamSticksCount must be positive", nameof(_ramSticksCount));
            }

            if (_bios == null)
            {
                throw new ArgumentNullException(nameof(_bios), "BIOS can't be null");
            }

            return new Motherboard(_name, _socket, _pcieCount, _sataCount, _chipset, _ddrType, _ramSticksCount, _formFactor, _bios, _hasWifiAdapter);
        }
    }
}
