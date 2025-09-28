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

var printer = new Printer(color: Printer.Color.Green, symbol: '$');

printer.Print("Text");


/*using (Printer printer = new Printer(Printer.Color.Purple, (0, 0), '#'))
{
    printer.Print("Text");
    printer.Print("Test");
}*/
