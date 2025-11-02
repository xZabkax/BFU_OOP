namespace Lab_7;

public static class ConfigC
{
    public static void Configure(Injector injector)
    {
        injector.Register<IInterface1, Class1Release>(LifeStyle.Singleton);
        injector.Register<IInterface2>(() =>
        {
            Class2Release impl = new();
            impl.Execute2();
            return impl;
        },
            LifeStyle.Scoped);
        injector.Register<IInterface3, Class3Release>(LifeStyle.PerRequest, parameters: new() { { "attribute1", "TEST" } } );
    }
}