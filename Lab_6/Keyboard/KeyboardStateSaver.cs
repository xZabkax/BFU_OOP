using System.Text.Json;

namespace Lab_6;

public static class KeyboardStateSaver
{
    private const string KeyBindingsFilePath = "bindings.json";

    public static void SaveState(Keyboard.Memento memento, string bindingsFilePath = KeyBindingsFilePath)
    {
        var bindings = memento.GetBindings()
            .Select(item => new KeyValuePair<string,string>(item.Key, item.Value.GetType().Name));

        try
        {
            var json = JsonSerializer.Serialize(bindings);
            File.WriteAllText(bindingsFilePath, json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static Keyboard.Memento LoadState(Keyboard keyboard, string bindingsFilePath = KeyBindingsFilePath)
    {
        try
        {
            if (!File.Exists(bindingsFilePath))
            {
                Console.WriteLine($"File with name \"{bindingsFilePath}\" not found");
            }

            var str = File.ReadAllText(bindingsFilePath);
            //var json = JsonSerializer.Deserialize<>();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}