using System.Text.Json;

namespace Lab_6;

public static class KeyboardStateSaver
{
    private const string KeyBindingsFilePath = @"res\bindings.json";

    public static void Save(Keyboard keyboard, string path = KeyBindingsFilePath)
    {
        if (keyboard.IsBindingsEmptyOrNull()) return;
        
        try
        {
            var bindings = (Keyboard.Memento)keyboard.SaveState();
            var bindingsToSave = bindings.GetBindings()
                .Select(item => new KeyValuePair<string, string>(item.Key, item.Value.GetType().Name))
                .ToDictionary();
            var json = JsonSerializer.Serialize(bindingsToSave);
            
            File.WriteAllText(KeyBindingsFilePath, json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Load(Keyboard keyboard, string path = KeyBindingsFilePath)
    {
        Dictionary<string, Command> bindingsToLoad;
        
        try
        {
            if (!File.Exists(path))
            {
                bindingsToLoad = new Dictionary<string, Command>();
            }
            else if (string.IsNullOrWhiteSpace(File.ReadAllText(path)))
            {
                bindingsToLoad = new Dictionary<string, Command>();
            }
            else
            {
                var bindings = JsonSerializer
                    .Deserialize<Dictionary<string, string>>(File.ReadAllText(path)) ?? new Dictionary<string, string>();
                bindingsToLoad = RestoreCommands(keyboard, bindings);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        Keyboard.Memento memento = new Keyboard.Memento(keyboard, bindingsToLoad, "");
        memento.RestoreState();
    }

    private static Dictionary<string, Command> RestoreCommands(Keyboard keyboard, Dictionary<string, string> dict)
    {
        var bindings = new Dictionary<string, Command>();
        var mediaPlayer = MediaPlayer.GetInstance();
        foreach (var item in dict)
        {
            switch (item.Value)
            {
                case nameof(PrintCharCommand):
                    bindings.Add(item.Key, new PrintCharCommand(keyboard, item.Key[0]));
                    break;
                case nameof(MediaPlayerLaunchCommand):
                    bindings.Add(item.Key, new MediaPlayerLaunchCommand(mediaPlayer));
                    break;
                case nameof(MediaPlayerCloseCommand):
                    bindings.Add(item.Key, new MediaPlayerCloseCommand(mediaPlayer));
                    break;
                case nameof(VolumeUpCommand):
                    bindings.Add(item.Key, new VolumeUpCommand(mediaPlayer));
                    break;
                case nameof(VolumeDownCommand):
                    bindings.Add(item.Key, new VolumeDownCommand(mediaPlayer));
                    break;
            }
        }

        return bindings;
    }
}