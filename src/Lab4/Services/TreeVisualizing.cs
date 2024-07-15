using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class TreeVisualizing
{
    private readonly string _folderIcon;
    private readonly string _fileIcon;

    public TreeVisualizing(string folderIcon, string fileIcon)
    {
        _fileIcon = fileIcon;
        _folderIcon = folderIcon;
    }

    public string Indent { get; private set; } = "   ";

    public string Result { get; private set; } = string.Empty;

    public void Visualize(int depth, string indent, TreeFolder folder)
    {
        if (depth == 0)
        {
            return;
        }

        if (folder == null)
        {
            throw new ArgumentNullException(nameof(folder));
        }

        Result += indent + _folderIcon + folder.Name + ":\n";
        foreach (ITreeComponent component in folder.Components)
        {
            if (component is TreeFile treeFile)
            {
                Result += indent + Indent + _fileIcon + treeFile.Name + "\n";
            }

            if (component is TreeFolder treeFolder)
            {
                Visualize(depth - 1, indent + Indent, treeFolder);
            }
        }
    }
}