using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab_2;

public class Printer
{
    private string _text;
    private int _color = (int)Color.Black;
    private (int, int) _position;
    private char _symbol = '*';

    public static void Print(string text, (int Left, int Top) position = default, int color = (int)Color.Black, char symbol = '*')
    {
        var font = ReadFont(symbol: symbol);
        
        if (!ValidateText(text, font))
        {
            throw new Exception("Incorrect input");
        }
        
        text = text.ToUpper();

        const int fontSizeCoef = 5;
        
        Console.SetCursorPosition(position.Left * fontSizeCoef, position.Top *fontSizeCoef);

        Console.ForegroundColor = (ConsoleColor)color;
        
        foreach (var letter in text)
        {
            var cursorPosition = Console.GetCursorPosition();
            for (int i = 0; i < font[letter].Count; i++)
            {
                Console.Write(font[letter][i]);
                Console.CursorTop += 1;
                Console.CursorLeft = cursorPosition.Left;
            }

            Console.CursorLeft += font[letter].Count + 1;
            Console.CursorTop = 0;
        }

        Console.CursorLeft = 0;
        Console.CursorTop = 5;

    }

    private static Dictionary<char, List<string>> ReadFont(string fontFilePath = @"C:\Users\perva\RiderProjects\BFU_OOP\Lab_2\font.txt",
        char symbol = '*')
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
                    
                    while ((line = reader.ReadLine()) is not "")
                    {
                        if (line is null)
                        {
                            break;
                        }

                        letterFromFont.Add(line.Replace('*', symbol));
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
    White = 37
}