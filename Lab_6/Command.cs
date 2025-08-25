namespace Lab_6;

public abstract class Command
{
    protected IOriginator _originator;
    private IMemento _memento;
    
    protected Command(IOriginator originator)
    {
        _originator = originator;
    }

    protected void SaveBackup()
    {
        _memento = _originator.SaveState();
    }

    public virtual void Undo()
    {
        if (_memento != null)
        {
            _memento.RestoreState();
        }
    }

    public abstract void Execute();
    public abstract void Redo();
    
}