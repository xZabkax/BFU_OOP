namespace Lab_6;

public class Keyboard : IOriginator
{
    private Dictionary<string, Command> _keyBindings;
    private readonly CommandManager _commandManager;
    public readonly OutputManager Output;

    public Keyboard()
    {
        _commandManager = new CommandManager();
        Output = new OutputManager();
        KeyboardStateSaver.Load(this);
    }
    
    public void AddKeyBinding(string key, Command command)
    {
        if (_keyBindings.TryGetValue(key, out var existingCommand))
        {
            Console.WriteLine($"Key binding already exists {(key, existingCommand)}");
        }
        else
        {
            _keyBindings.Add(key, command);
        }
    }

    public void ChangeKeyBinding(string key, Command command)
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
            _commandManager.ActivateCommand(command);
        }
        else
        {
            Console.WriteLine($"Key binding \"{key}\" is undefined");
        }
    }

    public void Undo()
    {
        _commandManager.Undo();
    }

    public void Redo()
    {
        _commandManager.Redo();
    }
    
    public bool IsBindingsEmptyOrNull() => _keyBindings.Count == 0 || _keyBindings == null;
    
    public IMemento SaveState()
    {
        return new Memento(this, _keyBindings, Output.Text);
    }

    public record Memento : IMemento
    {
        private readonly Keyboard _keyboard;
        private readonly Dictionary<string, Command> _keyBindings;
        private readonly string _text;

        public Memento(Keyboard keyboard, Dictionary<string, Command> keyBindings, string text)
        {
            _keyboard = keyboard;
            _keyBindings = keyBindings;
            _text = text;
        }

        public void RestoreState()
        {
            _keyboard._keyBindings = _keyBindings;
            _keyboard.Output.Text = _text;
        }

        public Dictionary<string, Command> GetBindings() => _keyBindings;
    }
}