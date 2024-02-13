namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.MemFs;

public class File : IHaveName, ICloneableFile
{
    public File(string name, Directory parent, string? data = null)
    {
        Name = name;
        Data = data;
        Parent = parent;
    }

    public Directory Parent { get; }
    public string Name { get; set; }
    public string? Data { get; set; }
    public FileInfo Clone()
    {
        return new(Name, Data);
    }
}