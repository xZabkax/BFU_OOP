using Lab_3;

var filters = new List<ILogFilter>
{
    new SimpleLogFilter("ERROR"),
    new RegexLogFilter(@"\d{3}-\d{4}")
};

var handlers = new List<ILogHandler>
{
    new ConsoleHandler(),
    new FileHandler(@"C:\Users\perva\RiderProjects\BFU_OOP\Lab_3\log.txt"),
    new SocketHandler(),
    new SysLogHandler()
};

var logger = new Logger(filters, handlers);

logger.Log("ERROR 404: Ресурс не найден [123-4567]");
logger.Log("WARNING: Незначительная проблема");
logger.Log("ERROR 500: Внутренняя ошибка сервера [890-1234]");

Console.WriteLine("\nЛогирование завершено. Проверьте файл log.txt");