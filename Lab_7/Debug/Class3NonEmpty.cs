namespace Lab_7;

public class Class3NonEmpty : IInterface3
{
    private readonly IInterface1 _dep;
    private readonly string _message;
    public Class3NonEmpty(IInterface1 dep, string message)
    {
        _dep = dep;
        _message = message;
    }
    public void Execute() { Console.WriteLine("Class3NonEmpty running " + _message); _dep.DoSomething(); }
}