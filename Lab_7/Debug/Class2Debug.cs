namespace Lab_7;

public class Class2Debug : IInterface2
{
    private object Attribute1;
    private object Attribute2;

    public Class2Debug(object attribute1, object attribute2)
    {
        Attribute1 = attribute1;
        Attribute2 = attribute2;
    }

    public void Execute2()
    {
        Console.WriteLine("Class2Debug running");
    }
}