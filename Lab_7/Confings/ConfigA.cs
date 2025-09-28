namespace Lab_7;

public static class ConfigA
{
    public static void Configure(Injector injector)
    {
        injector.Register<IInterface1, Class1Debug>(LifeStyle.Singleton);
        injector.Register<IInterface2, Class2Debug>(LifeStyle.Scoped);
        injector.Register<IInterface3, Class3Debug>(LifeStyle.PerRequest);
    }
}