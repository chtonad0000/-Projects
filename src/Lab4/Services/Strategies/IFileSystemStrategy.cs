using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;

public interface IFileSystemStrategy
{
    public string AbsolutePath { get; }
    public IFile ReturnFile(string path, string name);
    public IFolder ReturnFolder(string path);
    public void Show(int depth, IWriter writer);
}