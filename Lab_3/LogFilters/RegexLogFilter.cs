using System.Text.RegularExpressions;

namespace Lab_3;

public class RegexLogFilter(string pattern) : ILogFilter
{
    private readonly Regex _regex = new Regex(pattern);

    public bool IsMatch(string text)
    {
        try
        {
            return _regex.IsMatch(text);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    } 
}