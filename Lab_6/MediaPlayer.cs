namespace Lab_6;

public class MediaPlayer : IOriginator
{
    private static MediaPlayer _instance;
    public bool IsLaunched { get;  private set; }
    private byte _volumeLevel = 40;

    public byte VolumeLevel
    {
        get => _volumeLevel;
        private set
        {
            if (value > 100)
                _volumeLevel = 100;
            else if (value < 0)
                _volumeLevel = 0;
            else
                _volumeLevel = value;
        }
    }

    private MediaPlayer()
    {
    }

    public static MediaPlayer GetInstance()
    {
        return _instance ?? new MediaPlayer();
    }

    public void Launch()
    {
        IsLaunched = true;
        OutputManager.Write("Media player launched");
    }

    public void Close()
    {
        IsLaunched = false;
        OutputManager.Write("Media player closed");
    }

    public void VolumeUp()
    {
        if (!IsLaunched)
        {
            OutputManager.Write("To change the volume level, you must first launch the media player.");
        }
        else
        {
            VolumeLevel += 20;
            OutputManager.Write($"Volume increased +20% (Volume: {VolumeLevel})");
        }
    }

    public void VolumeDown()
    {
        if (!IsLaunched)
        {
            OutputManager.Write("To change the volume level, you must first launch the media player.");
        }
        else
        {
            VolumeLevel -= 20;
            OutputManager.Write($"Volume decreased -20% (Volume: {VolumeLevel})");
        }
    }

    public IMemento SaveState()
    {
        return new Memento(this, IsLaunched, VolumeLevel);
    }

    private record Memento : IMemento
    {
        private readonly MediaPlayer _mediaPlayer;
        private readonly bool _isLaunched;
        private readonly byte _volumeLevel;

        public Memento(MediaPlayer mediaPlayer, bool isLaunched, byte volumeLevel)
        {
            _mediaPlayer = mediaPlayer;
            _isLaunched = isLaunched;
            _volumeLevel = volumeLevel;
        }

        public void RestoreState()
        {
            _mediaPlayer.IsLaunched = _isLaunched;
            _mediaPlayer.VolumeLevel = _volumeLevel;
        }
    }
}