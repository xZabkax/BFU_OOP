namespace Lab_3;

public class SimpleLogFilter(string pattern) : ILogFilter
{
    public bool IsMatch(string text)
    {
        try
        {
            return text.Contains(pattern);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}