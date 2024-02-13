namespace AtmApi.Exception;

public class NotPermitedException : System.Exception
{
    public NotPermitedException(string message)
        : base(message)
    {
    }

    public NotPermitedException()
    {
    }

    public NotPermitedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}