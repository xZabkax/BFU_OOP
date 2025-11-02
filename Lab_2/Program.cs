using Lab_2;

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

Printer.Print("Static method", Printer.Color.Red);

using (var printer = new Printer(Printer.Color.Green, (0, 1), '$'))
{
    printer.Print("Instance writing");
    printer.Print("One more time");
}

Printer.Print("The end", position: (15, 0));

Console.ReadKey();