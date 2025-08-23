namespace Lab_6;

public class Keyboard
{
    private Dictionary<string, ICommand> _keyBindings = new();
    private readonly Stack<ICommand> _undoStack  = new();
    private readonly Stack<ICommand> _redoStack = new();
    public const string OutputFilePath = "output.txt";
    public List<char> TextBuffer { get; } = new();

    static Keyboard()
    {
        try
        {
            File.WriteAllText(OutputFilePath, "");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void AddKeyBinding(string key, ICommand command)
    {
        _keyBindings.Add(key, command);
    }

    public void ChangeKeyBinding(string key, ICommand command)
    {
        if (_keyBindings.ContainsKey(key))
        {
            _keyBindings[key] = command;
        }
        else
        {
            Console.WriteLine($"Key binding \"{key}\" is undefined");
        }
    }

    public void ActivateKeyBinding(string key)
    {
        if (_keyBindings.TryGetValue(key, out var command))
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
            Console.WriteLine(key);
        }
        else
        {
            Console.WriteLine($"Key binding \"{key}\" is undefined");
        }
    }

    public void Undo()
    {
        if (_undoStack.Count == 0) return;
        
        ICommand command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
        Console.WriteLine("Undo");
    }

    public void Redo()
    {
        if (_redoStack.Count == 0) return;
        
        ICommand command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
        Console.WriteLine("Redo");
    }

    public Memento SaveState()
    {
        return new Memento(_keyBindings);
    }
    
    public void LoadState(Memento memento)
    {
        _keyBindings = memento.GetBindings();
    }
    

    public record Memento
    {
        private readonly Dictionary<string, ICommand> _keyBindings;

        public Memento(Dictionary<string, ICommand> keyBindings)
        {
            _keyBindings = keyBindings;
        }

        internal Dictionary<string, ICommand> GetBindings() => _keyBindings;
    }
    
}