using Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IFile : IFileSystemComponent
{
    public string Path { get; }
    public string Text { get; }
    public void Rename(string newName);

    public void Copy(IFolder folder);

    public void Delete();

    public void Move(IFolder folder);
}