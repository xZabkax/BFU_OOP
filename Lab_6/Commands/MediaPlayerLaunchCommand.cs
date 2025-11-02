namespace Lab_6;

public class MediaPlayerLaunchCommand : Command
{
    private readonly MediaPlayer _mediaPlayer;

    public MediaPlayerLaunchCommand() : base(MediaPlayer.GetInstance())
    {
        _mediaPlayer = MediaPlayer.GetInstance();
    }
    
    public override void Execute()
    {
        SaveBackup();
        _mediaPlayer.Launch();
    }

    public override void Redo()
    {
        _mediaPlayer.Launch();
    }

    public override void Undo()
    {
        base.Undo();
        _mediaPlayer.Close();
    }
}