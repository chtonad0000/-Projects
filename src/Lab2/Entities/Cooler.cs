using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cooler : IComponent<Cooler>
{
    private Cooler(string name, double height, Collection<Socket> sockets, int maxTdp)
    {
        Name = name;
        Sockets = sockets;
        Height = height;
        MaxTdp = maxTdp;
    }

    public string Name { get; private set; }
    public double Height { get; private set; }
    public Collection<Socket> Sockets { get; private set; }
    public int MaxTdp { get; private set; }

    public Cooler Clone()
    {
        return new Cooler(Name, Height, Sockets, MaxTdp);
    }

    public class CoolerBuilder
    {
        private string? _name;
        private double _height;
        private Collection<Socket>? _sockets;
        private int _maxTdp;

        public CoolerBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public CoolerBuilder SetHeight(double height)
        {
            _height = height;

            return this;
        }

        public CoolerBuilder SetSockets(Collection<Socket> sockets)
        {
            _sockets = sockets;

            return this;
        }

        public CoolerBuilder SetMaxTdp(int maxTdp)
        {
            _maxTdp = maxTdp;

            return this;
        }

        public Cooler Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("name can't be null", nameof(_name));
            }

            if (_height <= 0)
            {
                throw new ArgumentException("height must be positive", nameof(_height));
            }

            if (_sockets == null || _sockets.Count == 0)
            {
                throw new ArgumentException("sockets can't be empty", nameof(_sockets));
            }

            if (_maxTdp <= 0)
            {
                throw new ArgumentException("maxTdp must be positive", nameof(_maxTdp));
            }

            return new Cooler(_name, _height, _sockets, _maxTdp);
        }
    }
}