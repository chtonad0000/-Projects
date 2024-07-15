using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WifiAdapter : IComponent<WifiAdapter>
{
    private WifiAdapter(string name, string wifiVersion, bool bluetoothModule, string pcieVersion, int powerConsumption)
    {
        Name = name;
        WifiVersion = wifiVersion;
        BluetoothModule = bluetoothModule;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; private set; }
    public string WifiVersion { get; private set; }
    public bool BluetoothModule { get; private set; }
    public string PcieVersion { get; private set; }
    public int PowerConsumption { get; private set; }

    public WifiAdapter Clone()
    {
        return new WifiAdapter(Name, WifiVersion, BluetoothModule, PcieVersion, PowerConsumption);
    }

    public class WifiAdapterBuilder
    {
        private string? _name;
        private string? _wifiVersion;
        private bool _bluetoothModule;
        private string? _pcieVersion;
        private int _powerConsumption;

        public WifiAdapterBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public WifiAdapterBuilder SetWifiVersion(string wifiVersion)
        {
            _wifiVersion = wifiVersion;

            return this;
        }

        public WifiAdapterBuilder SetBluetoothModule()
        {
            _bluetoothModule = true;

            return this;
        }

        public WifiAdapterBuilder SetPcieVersion(string pcieVersion)
        {
            _pcieVersion = pcieVersion;

            return this;
        }

        public WifiAdapterBuilder SetPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public WifiAdapter Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("Name can't be empty", nameof(_name));
            }

            if (string.IsNullOrEmpty(_wifiVersion))
            {
                throw new ArgumentException("WifiVersion can't be empty", nameof(_wifiVersion));
            }

            if (string.IsNullOrEmpty(_pcieVersion))
            {
                throw new ArgumentException("PcieVersion can't be empty", nameof(_pcieVersion));
            }

            if (_powerConsumption <= 0)
            {
                throw new ArgumentException("PowerConsumption must be positive", nameof(_powerConsumption));
            }

            return new WifiAdapter(_name, _wifiVersion, _bluetoothModule, _pcieVersion, _powerConsumption);
        }
    }
}