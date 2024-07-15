using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public abstract class FactoryBase<T> : IFactory<T>
    where T : IComponent<T>
{
    private readonly IEnumerable<T> _componentList;

    protected FactoryBase(IEnumerable<T> componentList)
    {
        _componentList = componentList;
    }

    public T CreateByName(string name)
    {
        T? result = _componentList
            .FirstOrDefault(component => component.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (result is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        return result.Clone();
    }
}