namespace Lab_3;

public class FileHandler(string filePath) : ILogHandler
{
    private readonly string _filePath = filePath;

    public void Handle(string text) => File.AppendAllText(_filePath, $"{DateTime.Now} {text}\n");
}