namespace ConsoleApp1.Exceptions;

public class NoSuchCommandException : Exception
{
    public NoSuchCommandException(string message)
        : base(message)
    {
    }

    public NoSuchCommandException()
    {
    }

    public NoSuchCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}