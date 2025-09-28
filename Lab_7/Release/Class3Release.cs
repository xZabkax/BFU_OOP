namespace Lab_7;

public class Class3Release : IInterface3
{
    private readonly IInterface2 _dep;
    public Class3Release(IInterface2 dep) => _dep = dep;
    public void Execute() { Console.WriteLine("Class3Release executing"); _dep.Run(); }
}