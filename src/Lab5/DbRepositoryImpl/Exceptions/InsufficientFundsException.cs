namespace DbRepositoryImpl.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InsufficientFundsException()
    {
    }

    public InsufficientFundsException(string message)
        : base(message)
    {
    }
}