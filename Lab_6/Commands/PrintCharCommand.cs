namespace Lab_6;

public class PrintCharCommand : ICommand
{
    private readonly char _char;
    private readonly List<char> _textBuffer;

    public PrintCharCommand(char c, List<char> textBuffer)
    {
        _char = c;
        _textBuffer = textBuffer;
    }

    public void Execute()
    {
        _textBuffer.Add(_char);
        string str = string.Concat(_textBuffer);
        
        try
        {
            File.AppendAllText(Keyboard.OutputFilePath, str + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Undo()
    {
        if (_textBuffer.Count == 0) return;
        
        _textBuffer.RemoveAt(_textBuffer.Count - 1);
        string str = string.Concat(_textBuffer);
        
        try
        {
            File.AppendAllText(Keyboard.OutputFilePath, str + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}