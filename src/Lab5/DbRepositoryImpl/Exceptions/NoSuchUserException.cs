namespace DbRepositoryImpl.Exceptions;

public class NoSuchUserException : Exception
{
    public NoSuchUserException(string message)
        : base(message)
    {
    }

    public NoSuchUserException()
    {
    }

    public NoSuchUserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}