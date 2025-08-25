namespace Lab_6;

public class PrintCharCommand : Command
{
    private readonly Keyboard _keyboard;
    private readonly char _key;

    public PrintCharCommand(Keyboard keyboard, char key) : base(keyboard)
    {
        _keyboard = keyboard;
        _key = key;
    }

    public override void Execute()
    {
        SaveBackup();
        _keyboard.Output.AddChar(_key);
    }

    public override void Redo()
    {
        _keyboard.Output.AddChar(_key);
    }

    public override void Undo()
    {
        base.Undo();
        _keyboard.Output.Write(_keyboard.Output.Text);
    }
}