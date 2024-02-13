namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.MemFs;

public class FileInfo
{
    public FileInfo(string name, string? data = null)
    {
        Name = name;
        Data = data;
    }

    public string Name { get; }
    public string? Data { get; }
}