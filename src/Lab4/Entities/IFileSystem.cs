namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;
public enum ConnectionMode
{
    Local,
    Virtual,
    Disconnected,
}

public interface IFileSystem
{
    public ConnectionMode ConnectionMode { get; }
    public string WorkingDir();
    public void TouchDir(string name);                          // no absolut path support
    public void TouchFile(string name, string? data = null);    // no absolut path support
    public bool ChangeDirectory(string destination);
    public string List(string? dirname, int depth);
    public string Concat(string filePath);
    public void Move(string source, string destination);
    public void Copy(string source, string destination);
    public void Remove(string filePath);
    public void Rename(string fileName, string newName);
}