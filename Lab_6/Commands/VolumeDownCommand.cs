namespace Lab_6;

public class VolumeDownCommand : Command
{
    private readonly MediaPlayer _mediaPlayer;
    public VolumeDownCommand(MediaPlayer mediaPlayer) : base(mediaPlayer)
    {
        _mediaPlayer = mediaPlayer;
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
        base.Undo();
        _mediaPlayer.VolumeUp();
    }
}