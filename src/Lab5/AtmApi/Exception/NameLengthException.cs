namespace AtmApi.Exception;

public class NameLengthException : System.Exception
{
    public NameLengthException(string message)
        : base(message)
    {
    }

    public NameLengthException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NameLengthException()
    {
    }
}