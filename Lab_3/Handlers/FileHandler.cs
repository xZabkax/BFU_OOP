namespace Lab_3;

public class FileHandler : ILogHandler
{
    private readonly string _filePath;

    public FileHandler(string filePath)
    {
        _filePath = filePath;
    }

    public void Handle(string text)
    {
        try
        {
            File.AppendAllText(_filePath, $"{DateTime.Now} {text}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine($"File error: {e.Message}");
            throw;
        }
    } 
}