namespace Lab_6;

public record KeyboardMemento
{
   private readonly Dictionary<string, ICommand> _keyBindings;

   public KeyboardMemento(Dictionary<string, ICommand> keyBindings)
   {
      _keyBindings = keyBindings;
   }

   public Dictionary<string, ICommand> GetBindings() => _keyBindings;
}