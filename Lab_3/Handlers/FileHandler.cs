namespace Lab_3;

public class FileHandler(string filePath) : ILogHandler
{
    public void Handle(string text)
    {
        try
        {
            File.AppendAllText(filePath, $"{DateTime.Now} {text}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    } 
}