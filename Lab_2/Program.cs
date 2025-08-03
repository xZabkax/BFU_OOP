using Lab_2;

//var printer = new Printer(color: Printer.Color.Green, symbol: '$');

using (Printer printer = new Printer(Printer.Color.Purple, (0, 0), '#'))
{
    printer.Print("Text");
    printer.Print("zaba");
}
