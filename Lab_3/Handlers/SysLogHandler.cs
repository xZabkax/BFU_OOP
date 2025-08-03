namespace Lab_3;

public class SysLogHandler : ILogHandler
{
    public void Handle(string text) => Console.WriteLine($"[SYSLOG] {DateTime.Now} Written in the system log: {text}");
}