using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.MemFs;

public class Directory : IHaveName
{
    public Directory(string name, Directory? parent = null)
    {
        if (name != "/" && parent == null)
            throw new DirectoryException("Can not create directory without a parent if it's not an fs root");

        Name = name;
        Parent = parent;
    }

    public Directory(string name, Directory parent, IList<File> files, IList<Directory> dirs)
    {
        Name = name;
        Parent = parent;
        Files = files;
        Directories = dirs;
    }

    public string Name { get; set; }
    public Directory? Parent { get; }
    public IList<File> Files { get; } = new List<File>();
    public IList<Directory> Directories { get; } = new List<Directory>();
}