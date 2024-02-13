namespace ConsoleApp1.LoggerDecorator;

public class Logger : ILogger
{
    private readonly TextWriter _writer;

    public Logger(TextWriter writer)
    {
        _writer = writer;
    }

    public void Log(string message)
    {
        _writer.WriteLine(message);
    }
}