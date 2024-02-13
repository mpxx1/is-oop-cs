using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.MemFs;

public class MemFs : IFileSystem
{
    private Directory _root = new("/");
    private Directory _currentDir;

    public MemFs()
    {
        _currentDir = _root;
    }

    public ConnectionMode ConnectionMode => ConnectionMode.Virtual;

    public string WorkingDir()
    {
        Directory cur = _currentDir;

        if (cur.Name == "/") return "/";

        IList<string> wdList = new List<string>();
        while (cur.Name != "/")
        {
            wdList.Add(cur.Name);
            cur = cur.Parent ?? throw new DirectoryException();
        }

        wdList.Add(string.Empty);
        IEnumerable<string> rev = wdList.Reverse();
        string wd = string.Join("/", rev);

        return wd;
    }

    public void TouchDir(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Contains('/', StringComparison.Ordinal))
            return;

        _currentDir
            .Directories
            .Add(new Directory(name, _currentDir));
    }

    public void TouchFile(string name, string? data = null)
    {
        if (string.IsNullOrEmpty(name) || name.Contains('/', StringComparison.Ordinal))
            return;

        File? file = _currentDir
            .Files
            .FirstOrDefault(file => file.Name == name);

        if (file != null)
        {
            _currentDir
                .Files
                .Remove(file);
        }

        _currentDir
            .Files
            .Add(new File(name, _currentDir, data));
    }

    public bool ChangeDirectory(string destination)
    {
        if (string.IsNullOrEmpty(destination)) return false;

        switch (destination)
        {
            case ".." when _currentDir.Name == "/":
                return true;
            case "..":
                _currentDir = _currentDir.Parent ?? throw new DirectoryException();
                return true;
            case "/":
                _currentDir = _root;
                return true;
        }

        Directory tmp = _currentDir;
        if (destination[0] == '/')
        {
            _currentDir = _root;
            destination = destination[1..];
        }

        string[] dirs = destination.Split('/');
        int depth = 0;

        while (depth < dirs.Length)
        {
            bool flag = false;
            foreach (Directory dir in _currentDir.Directories)
            {
                if (dir.Name != dirs[depth]) continue;

                _currentDir = dir;
                flag = true;
                ++depth;
                break;
            }

            if (flag) continue;
            _currentDir = tmp;
            return false;
        }

        return true;
    }

    public string List(string? dirname = null, int depth = 0)
    {
        if (depth < 0)
            return string.Empty;

        if (dirname == null)
        {
            return depth.Equals(0)
                ? OneLevelContents(_currentDir)
                : PrintDirectoryContents(_currentDir, 0, depth);
        }

        Directory tmp = _currentDir;
        if (!DirExists(dirname))
            return string.Empty;

        ChangeDirectory(dirname);
        string output;

        output = depth.Equals(0)
            ? OneLevelContents(_currentDir)
            : PrintDirectoryContents(_currentDir, 0, depth);
        _currentDir = tmp;

        return output;
    }

    public string Concat(string filePath)
    {
        Directory tmp = _currentDir;
        string dirName = System.IO.Path.GetDirectoryName(filePath) ?? throw new DirectoryException();
        string fileName = System.IO.Path.GetFileName(filePath);

        ChangeDirectory(dirName);

        File? file = _currentDir
            .Files
            .FirstOrDefault(file => file.Name == fileName);

        _currentDir = tmp;
        return file == null
            ? string.Empty
            : file.Data ?? string.Empty;
    }

    public void Move(string source, string destination)
    {
        Copy(source, destination);
        string fileName = System.IO.Path.GetFileName(source);

        if (FileExists(destination + "/" + fileName))
            Remove(source);
    }

    public void Copy(string source, string destination)
    {
        if (!FileExists(source) || !DirExists(destination)) return;

        Directory tmp = _currentDir;
        string dirName = System.IO.Path.GetDirectoryName(source) ?? throw new DirectoryException();
        string fileName = System.IO.Path.GetFileName(source);

        ChangeDirectory(dirName);
        FileInfo info = _currentDir
            .Files
            .First(file => file.Name == fileName)
            .Clone();

        ChangeDirectory(destination);

        File? old = _currentDir
            .Files
            .FirstOrDefault(file => file.Name == fileName);

        if (old != null)
        {
            _currentDir
                .Files
                .Remove(old);
        }

        _currentDir
            .Files
            .Add(new File(info.Name, _currentDir, info.Data));

        _currentDir = tmp;
    }

    public void Remove(string filePath)
    {
        if (!FileExists(filePath)) return;

        Directory tmp = _currentDir;
        string dirName = System.IO.Path.GetDirectoryName(filePath) ?? throw new DirectoryException();
        string fileName = System.IO.Path.GetFileName(filePath);

        ChangeDirectory(dirName);
        File file = _currentDir
            .Files
            .First(file => file.Name == fileName);

        _currentDir.Files.Remove(file);
        _currentDir = tmp;
    }

    public void Rename(string fileName, string newName)
    {
        if (string.IsNullOrEmpty(newName) ||
            string.IsNullOrEmpty(fileName)) return;

        if (_currentDir
            .Files
            .FirstOrDefault(file => file.Name == fileName) == null) return;

        if (newName.Contains('/', StringComparison.Ordinal)) return;

        File file = _currentDir
            .Files
            .First(file => file.Name == fileName);

        file.Name = newName;
    }

    private bool DirExists(string dir)
    {
        Directory curTmp = _currentDir;
        if (!ChangeDirectory(dir)) return false;

        _currentDir = curTmp;
        return true;
    }

    private bool FileExists(string filePath)
    {
        if (string.IsNullOrEmpty(filePath)) return false;

        Directory tmp = _currentDir;
        string? dirName = null;
        if (filePath[0] == '/')
        {
            dirName = System.IO.Path.GetDirectoryName(filePath) ?? throw new DirectoryException();
            if (!DirExists(dirName)) return false;
        }

        string fileName = System.IO.Path.GetFileName(filePath);

        if (dirName != null)
            ChangeDirectory(dirName);

        if (_currentDir
                .Files
                .FirstOrDefault(file => file.Name == fileName) == null) return false;

        _currentDir = tmp;
        return true;
    }

    private string OneLevelContents(Directory directory)
    {
        var output = new StringBuilder();
        output.AppendLine(directory.Name + " \u23ce");

        foreach (Directory dir in directory.Directories)
        {
            output.AppendLine('\t' + dir.Name + " \u23ce");
        }

        foreach (File file in directory.Files)
        {
            output.AppendLine('\t' + file.Name);
        }

        return output.ToString();
    }

    private string PrintDirectoryContents(Directory directory, int currentDepth, int maxDepth)
    {
        var output = new StringBuilder();
        output.Append(new string('\t', currentDepth) + directory.Name + " \u23ce");

        output.AppendLine();

        foreach (File file in directory.Files)
        {
            output.AppendLine(new string('\t', currentDepth + 1) + file.Name);
        }

        if (currentDepth >= maxDepth) return output.ToString();
        foreach (Directory subDirectory in directory.Directories)
        {
            string subDirectoryContents = PrintDirectoryContents(subDirectory, currentDepth + 1, maxDepth);
            output.Append(subDirectoryContents);
        }

        return output.ToString();
    }
}