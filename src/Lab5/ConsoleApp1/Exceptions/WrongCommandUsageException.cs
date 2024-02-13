namespace ConsoleApp1.Exceptions;

public class WrongCommandUsageException : Exception
{
    public WrongCommandUsageException(string message)
        : base(message)
    {
    }

    public WrongCommandUsageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongCommandUsageException()
    {
    }
}