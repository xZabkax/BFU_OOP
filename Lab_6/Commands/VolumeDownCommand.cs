namespace Lab_6;

public class VolumeDownCommand : Command
{
    private readonly MediaPlayer _mediaPlayer;

    public VolumeDownCommand() : base(MediaPlayer.GetInstance())
    {
        _mediaPlayer = MediaPlayer.GetInstance();
    }

    public override void Execute()
    {
        SaveBackup();
        _mediaPlayer.VolumeDown();
    }

    public override void Redo()
    {
        _mediaPlayer.VolumeDown();
    }

    public override void Undo()
    {
        _mediaPlayer.VolumeUp();
    }
}