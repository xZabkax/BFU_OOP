namespace Lab_3;

public class SocketHandler : ILogHandler
{
    public void Handle(string text)
    {
        try
        {
            Console.WriteLine($"[SOCKET] {DateTime.Now} Sent: {text}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Socket error: {e.Message}");
            throw;
        }
    }
}