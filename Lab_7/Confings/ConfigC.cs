namespace Lab_7;

public static class ConfigC
{
    public static void Configure(Injector injector)
    {
        injector.Register<IInterface1, Class1Release>(LifeStyle.Singleton);
        injector.Register<IInterface2>(() =>
        {
            Class2Release impl = new();
            impl.Run();
            return impl;
        });
        injector.Register<IInterface3, Class3NonEmpty>(LifeStyle.PerRequest, parameters: new() { { "message", "TEST" } } );
    }
}