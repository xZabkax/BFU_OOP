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
var mediaPlayer = MediaPlayer.GetInstance();

var alphabet = new string(Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray());

foreach (var letter in alphabet)
{     
    keyboard.AddKeyBinding(letter.ToString(), new PrintCharCommand(keyboard, letter));
}

keyboard.AddKeyBinding("ctrl++", new VolumeUpCommand(mediaPlayer));
keyboard.AddKeyBinding("ctrl+-", new VolumeDownCommand(mediaPlayer));
keyboard.AddKeyBinding("ctrl+p", new MediaPlayerLaunchCommand(mediaPlayer));
keyboard.AddKeyBinding("ctrl+o", new MediaPlayerCloseCommand(mediaPlayer));

const string stopWord = "stop", undoWord = "undo", redoWord = "redo";

Console.WriteLine($"\nVirtual keyboard launched. To see the results check \"{keyboard.Output.GetPath()}\"\nEnter \"{stopWord}\" to close program");
while (true)
{
    var input = Console.ReadLine();

    switch (input)
    {
        case stopWord:
            goto SaveAndExit;
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

SaveAndExit:
    KeyboardStateSaver.Save(keyboard);



