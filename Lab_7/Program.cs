using Lab_7;

Injector injector = new();
Console.WriteLine("==== Using Config A ====");
ConfigA.Configure(injector);

using (var scope = new Scope(injector))
{
    var i3_1 = injector.GetInstance<IInterface3>();
    var i3_2 = injector.GetInstance<IInterface3>();
    Console.WriteLine($"Same IInterface3 in scope? {ReferenceEquals(i3_1, i3_2)}");

    i3_1.Execute3();
}

Console.WriteLine("\n==== Using Config B ====");
injector = new();
ConfigB.Configure(injector);

using (var scope = new Scope(injector))
{
    var i3_1 = injector.GetInstance<IInterface3>();
    var i3_2 = injector.GetInstance<IInterface3>();
    Console.WriteLine($"Same IInterface3 in scope? {ReferenceEquals(i3_1, i3_2)}");

    i3_1.Execute3();
}

Console.WriteLine("\n==== Using Config C ====");
injector = new();
ConfigC.Configure(injector);

IInterface3 i3 = injector.GetInstance<IInterface3>();
i3.Execute3();

IInterface2 i2 = injector.GetInstance<IInterface2>();