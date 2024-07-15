namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IFolder : IFileSystemComponent
{
    public string Path { get; }
}