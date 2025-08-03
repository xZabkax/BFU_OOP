namespace Lab_3;

public class SocketHandler : ILogHandler
{
    public void Handle(string text) => Console.WriteLine($"[SOCKET] {DateTime.Now} Sent: {text}");
}