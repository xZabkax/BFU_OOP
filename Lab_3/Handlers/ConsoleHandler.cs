namespace Lab_3;

public class ConsoleHandler : ILogHandler
{
    public void Handle(string text)
    {
        Console.WriteLine($"[CONSOLE] {DateTime.Now} {text}");
    }
}