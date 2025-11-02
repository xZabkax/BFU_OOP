namespace Lab_3;

public class Logger
{
    private readonly List<ILogFilter> _filters;
    private readonly List<ILogHandler> _handlers;

    public Logger(List<ILogFilter> filters, List<ILogHandler> handlers)
    {
        _filters = filters ?? new List<ILogFilter>();
        _handlers = handlers ?? new List<ILogHandler>();
    }
    
    public void Log(string text)
    {
        if (string.IsNullOrEmpty(text))
            return;
        
        foreach (var filter in _filters)
        {
            if(!filter.IsMatch(text)) return; // Сообщение не прошло фильтр
        }

        foreach (var handler in _handlers)
        {
            try
            {
                handler.Handle(text);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Handler error: {e.Message}");
                throw;
            }
            
        }
    }
}   