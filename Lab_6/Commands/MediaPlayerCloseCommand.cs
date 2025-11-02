namespace Lab_6;

public class MediaPlayerCloseCommand : Command
{
    private readonly MediaPlayer _mediaPlayer;

    public MediaPlayerCloseCommand() : base(MediaPlayer.GetInstance())
    {
        _mediaPlayer = MediaPlayer.GetInstance();
    }
    
    public override void Execute()
    {
        SaveBackup();
        _mediaPlayer.Close();
    }

    public override void Redo()
    {
        _mediaPlayer.Close();
    }

    public override void Undo()
    {
        base.Undo();
        _mediaPlayer.Launch();
    }
}