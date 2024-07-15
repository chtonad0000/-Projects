using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class WifiAdapterFactory : FactoryBase<WifiAdapter>
{
    public WifiAdapterFactory(IEnumerable<WifiAdapter> wifiAdapterList)
    : base(wifiAdapterList)
    {
    }
}