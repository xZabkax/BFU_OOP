namespace Lab_3;

public class SysLogHandler : ILogHandler
{
    public void Handle(string text)
    {
        try
        {
            Console.WriteLine($"[SYSLOG] {DateTime.Now} Written in the system log: {text}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"SysLog error: {e.Message}");
            throw;
        }
    }
}