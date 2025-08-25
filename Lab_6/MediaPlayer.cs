namespace Lab_6;

public class MediaPlayer : IOriginator
{
    public bool IsLaunched;
    private byte _volumeLevel = 40;

    public byte VolumeLevel
    {
        get => _volumeLevel;
        set
        {
            if (value > 100)
                _volumeLevel = 100;
            else if (value < 0)
                _volumeLevel = 0;
            else
                _volumeLevel = value;
        }
    }
    
    public void Launch()
    {
        OutputManager.Write("Media player launched");
    }

    public void Close()
    {
        OutputManager.Write("Media player closed");
    }

    public void VolumeUp()
    {
        VolumeLevel += 20;
        OutputManager.Write($"Volume increased +20% (Volume: {VolumeLevel})");
    }

    public void VolumeDown()
    {
        VolumeLevel -= 20;
        OutputManager.Write($"Volume decreased -20% (Volume: {VolumeLevel})");
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