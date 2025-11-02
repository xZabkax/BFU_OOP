namespace Lab_3;

public class SimpleLogFilter : ILogFilter
{
    private readonly string _pattern;

    public SimpleLogFilter(string pattern)
    {
        try
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentException("Pattern cannot be null or empty", nameof(pattern));

            _pattern = pattern;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Invalid SimpleLog pattern '{pattern}': {e.Message}");
            throw;
        }
    }

    public bool IsMatch(string text)
    {
        try
        {
            if (string.IsNullOrEmpty(text))
                return false;
            
            return text.Contains(_pattern);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{this.GetType()} error: {e.Message}");
            return false;
        }
    }
}