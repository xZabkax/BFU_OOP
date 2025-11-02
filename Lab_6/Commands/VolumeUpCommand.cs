namespace Lab_6;

public class VolumeUpCommand : Command
{
    private readonly MediaPlayer _mediaPlayer;

    public VolumeUpCommand() : base(MediaPlayer.GetInstance())
    {
        _mediaPlayer = MediaPlayer.GetInstance();
    }

    public override void Execute()
    {
        SaveBackup();
        _mediaPlayer.VolumeUp();
    }

    public override void Redo()
    {
        _mediaPlayer.VolumeUp();
    }

    public override void Undo()
    {
        _mediaPlayer.VolumeDown();
    }
}