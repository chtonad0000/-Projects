namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public interface IFactory<T>
{
    T CreateByName(string name);
}