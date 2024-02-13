namespace AtmApi.Exception;

public class PasswdBodyException : System.Exception
{
    public PasswdBodyException(string message)
        : base(message)
    {
    }

    public PasswdBodyException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public PasswdBodyException()
    {
    }
}