namespace Lab_6;

public class VolumeUpCommand : Command
{
    private readonly MediaPlayer _mediaPlayer;

    public VolumeUpCommand(MediaPlayer mediaPlayer) : base(mediaPlayer)
    {
        _mediaPlayer = mediaPlayer;
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
        base.Undo();
        _mediaPlayer.VolumeDown();
    }
}