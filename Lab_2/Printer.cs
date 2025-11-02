using System.Text;

namespace Lab_2;

public class Printer : IDisposable
{
    private static Dictionary<char, string[]> _font;
    
    private Color _color;
    private (int x, int y) _position;
    private char _symbol;
    
    private static readonly char _defaultSymbol = '*';
    private static readonly Color _defaultColor = Color.White;
    private static int _fontSize;

    static Printer()
    {
        LoadFont();
    }

    public Printer(Color color = Color.White, (int x, int y) position = default, char symbol = '*')
    {
        var scaledPosition = (position.x * (_fontSize + 1), position.y * (_fontSize + 1));
        
        _color = color;
        _position = scaledPosition;
        _symbol = symbol;
    }

    public void Print(string text)
    {
        SetColor(_color);
        Console.SetCursorPosition(_position.x, _position.y);
        PrintLine(text, _symbol);
    }
    
    public static void Print(string text, Color color = Color.White, (int x, int y) position = default, char symbol = '*')
    {
        using (var printer = new Printer(color, position, symbol))
        {
            printer.Print(text);
        }
    }

    private static void LoadFont(string fontFilePath = @".\resources\font_size_5.txt")
    {
        _font = new Dictionary<char, string[]>();

        if (!File.Exists(fontFilePath))
            throw new FileNotFoundException($"Font file \"{fontFilePath}\" not found");
        
        // Заполняем словарь псевдошрифтом
        using (StreamReader reader = File.OpenText(fontFilePath))
        {
            string line;
            char currentLetter;
            List<string> letterFromFont = new List<string>();

            while ((line = reader.ReadLine()) is not null)
            {
                if (line.Length == 1 && char.IsLetter(line[0]))
                {
                    currentLetter = line[0];
                    letterFromFont.Clear();

                    while (!string.IsNullOrWhiteSpace(line = reader.ReadLine()))
                    {
                        letterFromFont.Add(line);
                    }

                    _font.Add(currentLetter, letterFromFont.ToArray());
                }
            }

            // Отдельно добавляем пробел " " в словарь
            _fontSize = letterFromFont.Count;
            letterFromFont.Clear();
            for (int i = 0; i < _fontSize; i++)
            {
                letterFromFont.Add(new StringBuilder(_fontSize).Insert(0, " ", _fontSize).ToString());
            }

            _font.Add(' ', letterFromFont.ToArray());
        }
    }

    private static bool ValidateText(string text, Dictionary<char, string[]> font)
    {
        text = text.ToUpper();
        return text.All(c => font.ContainsKey(c));
    }

    private void PrintCharacter(char c, int startX, int startY, char symbol)
    {
        var charData = _font[c];
        for (int i = 0; i < charData.Length; i++)
        {
            Console.SetCursorPosition(startX, startY + i);
            string line = charData[i];
            if (symbol != _defaultSymbol)
            {
                line = line.Replace('*', symbol);
            }
            Console.Write(line);
        }
    }

    private void PrintLine(string text, char symbol)
    {
        if (!ValidateText(text, _font))
        {
            throw new Exception("Text contains not supported characters");
        }

        text = text.ToUpper();
        
        var currentY = _position.y;

        foreach (var c in text)
        {
            PrintCharacter(c, _position.x, _position.y, symbol);
            _position.y = currentY;
            _position.x += _fontSize + 1;
        }
        
        // Переносим курсор на следующую строку, учитывая размерность псевдашрифта.
        _position.x = 0;
        _position.y += _fontSize + 1;
    }

    private void SetColor(Color color)
    {
        Console.WriteLine($"\u001b[0;{(int)color}m");
    }

    private void SetSymbol(char c)
    {
        _symbol = c;
    }

    private void RestoreConsoleState()
    {
        SetColor(_defaultColor);
        SetSymbol(_defaultSymbol);
        Console.SetCursorPosition(0, 0);
    }

    public void Dispose()
    {
        RestoreConsoleState();
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

