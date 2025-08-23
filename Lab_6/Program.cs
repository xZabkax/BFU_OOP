using Lab_6;

var keyboard = new Keyboard();

keyboard.AddKeyBinding("a", new PrintCharCommand('a', keyboard.TextBuffer));
keyboard.AddKeyBinding("b", new PrintCharCommand('b', keyboard.TextBuffer));
keyboard.AddKeyBinding("c", new PrintCharCommand('c', keyboard.TextBuffer));
keyboard.AddKeyBinding("d", new PrintCharCommand('d', keyboard.TextBuffer));
keyboard.AddKeyBinding("ctrl++", new VolumeUpCommand());
keyboard.AddKeyBinding("ctrl+-", new VolumeDownCommand());
keyboard.AddKeyBinding("ctrl+p", new MediaPlayerCommand());

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

var bindings = keyboard.GetBindinds();

var bindingsToSave = bindings.Select(item
    => new KeyValuePair<string,string>(item.Key, item.Value.GetType().Name));

