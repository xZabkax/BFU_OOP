namespace Lab_6;

public class CommandManager
{
    private readonly Stack<Command> _undoStack = new();
    private readonly Stack<Command> _redoStack = new();
    
    public void ActivateCommand(Command command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.Count == 0) return;
        
        Command command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
        Console.WriteLine("Undo");
    }

    public void Redo()
    {
        if (_redoStack.Count == 0) return;
        
        Command command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
        Console.WriteLine("Redo");
    }
}