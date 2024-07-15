using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactorType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : IComponent<ComputerCase>
{
    private ComputerCase(string name, Size maxGpuSize, Collection<FormFactorType> motherboardFormFactors, Size size)
    {
        Name = name;
        MotherboardFormFactors = motherboardFormFactors;
        MaxGpuSize = maxGpuSize;
        Size = size;
    }

    public string Name { get; private set; }
    public Size MaxGpuSize { get; private set; }
    public Collection<FormFactorType> MotherboardFormFactors { get; private set; }
    public Size Size { get; private set; }

    public ComputerCase Clone()
    {
        return new ComputerCase(Name, new Size(MaxGpuSize.Length, MaxGpuSize.Height), MotherboardFormFactors, new Size(Size.Length, Size.Height));
    }

    public class ComputerCaseBuilder
    {
        private string? _name;
        private Size? _maxGpuSize;
        private Collection<FormFactorType>? _formFactors;
        private Size? _size;

        public ComputerCaseBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public ComputerCaseBuilder SetMaxGpuSize(Size maxGpuSize)
        {
            _maxGpuSize = maxGpuSize;

            return this;
        }

        public ComputerCaseBuilder SetMotherboardFormFactors(Collection<FormFactorType> formFactors)
        {
            _formFactors = formFactors;

            return this;
        }

        public ComputerCaseBuilder SetSize(Size size)
        {
            _size = size;

            return this;
        }

        public ComputerCase Build()
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("name can't be null", nameof(_name));
            }

            if (_maxGpuSize == null || _maxGpuSize.Length <= 0 || _maxGpuSize.Height <= 0)
            {
                throw new ArgumentException("invalid MaxGpuSize", nameof(_maxGpuSize));
            }

            if (_size == null || _size.Length <= 0 || _size.Height <= 0)
            {
                throw new ArgumentException("invalid Size", nameof(_size));
            }

            if (_formFactors == null || _formFactors.Count == 0)
            {
                throw new ArgumentException("formFactors can't be empty", nameof(_maxGpuSize));
            }

            return new ComputerCase(_name, _maxGpuSize, _formFactors, _size);
        }
    }
}