namespace Lab_6;

public class OutputManager
{
    public string Text { get; set; } = string.Empty;
    private const string OutputFilePath = @"res\output.txt";

    static OutputManager()
    {
        try
        {
            File.WriteAllText(OutputFilePath, "");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddChar(char c)
    {
        Text += c;
        Write(Text);
    }

    public void RemoveLastChar()
    {
        if (string.IsNullOrEmpty(Text)) return;
        
        Text = Text[..^1];
        Write(Text);
    }

    public static void Write(string content, string path = OutputFilePath)
    {
        try
        {
            File.AppendAllText(path, content + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void Write(string content)
    {
        try
        {
            File.AppendAllText(OutputFilePath, content + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}