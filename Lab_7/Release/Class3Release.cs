namespace Lab_7;

public class Class3Release : IInterface3
{
    private string Attribute1;
    private IInterface1 _interface1;

    public Class3Release()
    { }

    public Class3Release(string attribute1, IInterface1 interface1)
    {
        Attribute1 = attribute1;
        _interface1 = interface1;
    }

    public void Execute3()
    {
        Console.WriteLine("Class3Release running");
    }
}