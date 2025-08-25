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
var mediaPlayer = new MediaPlayer();

keyboard.AddKeyBinding("a", new PrintCharCommand(keyboard, 'a'));
keyboard.AddKeyBinding("b", new PrintCharCommand(keyboard, 'b'));
keyboard.AddKeyBinding("c", new PrintCharCommand(keyboard, 'c'));
keyboard.AddKeyBinding("d", new PrintCharCommand(keyboard, 'd'));
keyboard.AddKeyBinding("ctrl++", new VolumeUpCommand(mediaPlayer));
keyboard.AddKeyBinding("ctrl+-", new VolumeDownCommand(mediaPlayer));
keyboard.AddKeyBinding("ctrl+p", new MediaPlayerCommand(mediaPlayer));

keyboard.ActivateKeyBinding("a");
keyboard.ActivateKeyBinding("b");
keyboard.ActivateKeyBinding("c");

keyboard.Undo();
keyboard.Undo();
keyboard.Redo();

keyboard.ActivateKeyBinding("ctrl++");
keyboard.ActivateKeyBinding("ctrl+-");
keyboard.ActivateKeyBinding("ctrl+p");

keyboard.ActivateKeyBinding("d");
keyboard.Undo();
keyboard.Undo();

keyboard.ActivateKeyBinding("z");

KeyboardStateSaver.Save(keyboard);
