using Lab_6;

try
{
    var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
    Directory.SetCurrentDirectory(dir.Parent.Parent.Parent.FullName);
}
catch
{
    Console.WriteLine("Couldn't set a new working directory");
    throw;
}
finally
{
    Console.WriteLine("Current working directory: " + Directory.GetCurrentDirectory() +  "\n");
}

var keyboard = new Keyboard();

var alphabet = new string(Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray());

foreach (var letter in alphabet)
{     
    keyboard.AddKeyBinding(letter.ToString(), new PrintCharCommand(keyboard, letter));
}

keyboard.AddKeyBinding("ctrl++", new VolumeUpCommand());
keyboard.AddKeyBinding("ctrl+-", new VolumeDownCommand());
keyboard.AddKeyBinding("ctrl+p", new MediaPlayerLaunchCommand());
keyboard.AddKeyBinding("ctrl+o", new MediaPlayerCloseCommand());

const string stopWord = "stop", undoWord = "undo", redoWord = "redo";

Console.WriteLine($"\nVirtual keyboard is running. To see the results check \"{keyboard.Output.GetPath()}\"\n" +
                  $"Enter \"{stopWord}\" to close program, \"{undoWord}\" to undo and \"{redoWord}\" to redo");
while (true)
{
    var input = Console.ReadLine();

    switch (input)
    {
        case stopWord:
            KeyboardStateSaver.Save(keyboard);
            return;
        case undoWord:
            keyboard.Undo();
            break;
        case redoWord:
            keyboard.Redo();
            break;
        default:
            keyboard.ActivateKeyBinding(input);
            break;
    }
}



