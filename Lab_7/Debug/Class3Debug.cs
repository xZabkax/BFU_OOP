namespace Lab_7;

public class Class3Debug : IInterface3
{
    private readonly IInterface1 _dep;
    public Class3Debug(IInterface1 dep) => _dep = dep;
    public void Execute() { Console.WriteLine("Class3Debug executing"); _dep.DoSomething(); }
}