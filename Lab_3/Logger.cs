using System.Threading.Tasks;
namespace Lab_3;

public class Logger(
    IEnumerable<ILogFilter> filters,
    IEnumerable<ILogHandler> handlers
    )
{
    public void Log(string text)
    {
        foreach (var filter in filters)
        {
            if(!filter.IsMatch(text)) return; // Сообщение не прошло фильтр
        }

        foreach (var handler in handlers)
        {
            handler.Handle(text);
        }
    }
}   