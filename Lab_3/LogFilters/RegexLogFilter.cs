using System.Text.RegularExpressions;

namespace Lab_3;

public class RegexLogFilter : ILogFilter
{
    private readonly Regex _regex;

    public RegexLogFilter(string pattern)
    {
        try
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentException("Pattern cannot be null or empty", nameof(pattern));

            _regex = new Regex(pattern);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Invalid RegEx pattern '{pattern}': {e.Message}");
            throw;
        }
    }

    public bool IsMatch(string text)
    {
        try
        {
            if (string.IsNullOrEmpty(text))
                return false;
            
            return _regex.IsMatch(text);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{this.GetType()} error: {e.Message}");
            return false;
        }
    } 
}