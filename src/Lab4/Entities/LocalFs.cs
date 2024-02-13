using System;
using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class LocalFs : IFileSystem
{
    public ConnectionMode ConnectionMode => ConnectionMode.Local;

    public string WorkingDir()
    {
        return Environment.CurrentDirectory;
    }

    public void TouchDir(string name)
    {
        Directory.CreateDirectory(name);
    }

    public void TouchFile(string name, string? data = null)
    {
        File.WriteAllText(name, string.Empty);

        if (data != null)
            File.WriteAllText(name, data);
    }

    public bool ChangeDirectory(string destination)
    {
        Directory.SetCurrentDirectory(destination);
        return true;
    }

    public string List(string? dirname, int depth)
    {
        if (string.IsNullOrEmpty(dirname))
        {
            dirname = Directory.GetCurrentDirectory();
        }

        return ListDirectory(dirname, 0, depth + 1);
    }

    public string Concat(string filePath)
    {
        var builder = new StringBuilder();

        using (var reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                builder.AppendLine(line);
            }
        }

        return builder.ToString();
    }

    public void Move(string source, string destination)
    {
        File.Move(source, destination);
    }

    public void Copy(string source, string destination)
    {
        File.Copy(source, destination);
    }

    public void Remove(string filePath)
    {
        File.Delete(filePath);
    }

    public void Rename(string fileName, string newName)
    {
        string? directory = Path.GetDirectoryName(fileName);
        string newFilePath = Path.Combine(directory ?? throw new DirectoryException(), newName);

        File.Move(fileName, newFilePath);
    }

    private string ListDirectory(string directory, int currentDepth, int maxDepth)
    {
        var output = new StringBuilder();

        for (int i = 0; i < currentDepth; ++i)
            output.Append('\t');

        output
            .Append(directory)
            .AppendLine(" \u23ce");

        if (currentDepth >= maxDepth) return output.ToString();

        string[] files = Directory.GetFiles(directory);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            for (int i = 0; i <= currentDepth; ++i)
                output.Append('\t');

            output.AppendLine(fileName);
        }

        string[] directories = Directory.GetDirectories(directory);

        foreach (string dir in directories)
        {
            for (int i = 0; i < currentDepth; ++i)
                output.Append('\t');

            output
                .Append(ListDirectory(dir, currentDepth + 1, maxDepth));
        }

        return output.ToString();
    }
}