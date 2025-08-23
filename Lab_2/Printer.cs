using System.Text;

namespace Lab_2;

public class Printer : IDisposable
{
    private readonly Color _color;
    private readonly (int, int) _position;
    private readonly char _symbol;
    private static readonly Dictionary<char, List<string>> _font = LoadFont();
    private static readonly int _fontHeight = _font.Values.First().Count;         // Полагаем, что высота и ширина
    private static readonly int _fontWidth = _font.Values.First().First().Length; // одна и та же для каждого символа

    private int _savedCursorLeft;
    private int _savedCursorTop;

    private bool _disposed;

    public Printer(Color color = Color.White, (int, int) position = default, char symbol = '*')
    {
        _color = color;
        _position = position;
        _symbol = symbol;
    }

    public static void Print(string text, (int Left, int Top) position = default, Color color = Color.White, char symbol = '*')
    {
        if (!ValidateText(text, _font))
        {
            throw new Exception("Incorrect input");
        }
        
        text = text.ToUpper();
        
        Console.SetCursorPosition(position.Left * (_fontWidth+1), position.Top * _fontHeight);
        
        foreach (var letter in text)
        {
            for (int i = 0; i < _fontHeight; i++)
            {
                var output = $"\u001b[0;{(int)color}m{_font[letter][i]}\u001b[0m";
                if (symbol != '*')
                {
                    output = output.Replace('*', symbol);
                }
                Console.Write(output);
                Console.CursorTop += 1;
                Console.CursorLeft -= _fontWidth;
            }

            Console.CursorLeft += _fontWidth + 1;
            Console.CursorTop -= _fontHeight;
        }

        Console.CursorLeft = 0;
        Console.CursorTop += _fontHeight;
    }

    public void Print(string text)
    {

        (int, int) position = default;

        if (_position == default)
        {
            position = (Console.CursorLeft, Console.CursorTop);
        }
        
        Print(text, color: _color, position: position, symbol: _symbol);
        
    }

    private static Dictionary<char, List<string>> LoadFont(string fontFilePath = @".\resources\font.txt")
    {
        var fontDict = new Dictionary<char, List<string>>();
        
        // Заполняем словарь псевдошрифтом
        using (StreamReader reader = File.OpenText(fontFilePath))
        {
            string line;
            char currentLetter;
            while ((line = reader.ReadLine()) is not null)
            {
                if (line.Length == 1 && Char.IsLetter(line[0]))
                {
                    currentLetter = line[0];
                    List<string> letterFromFont = new List<string>();
                    
                    while (!string.IsNullOrWhiteSpace(line = reader.ReadLine()))
                    {
                        letterFromFont.Add(line);
                    }

                    fontDict.Add(currentLetter, letterFromFont);
                }
            }
        }
        
        // Добавляем отдельно пробел " " в словарь
        var emptySymbol = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            emptySymbol.Add(new StringBuilder(5).Insert(0, " " ,5).ToString());
        }
        fontDict.Add(' ', emptySymbol);
        
        return fontDict;
    }

    private static bool ValidateText(string text, Dictionary<char, List<string>> font)
    {
        text = text.ToUpper();
        return text.All(c => font.ContainsKey(c));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public enum Color
    {
        Black = 30,
        Red = 31,
        Green = 32,
        Yellow = 33,
        Blue = 34,
        Purple = 35,
        Cyan = 36,
        White = 39
    }
}

