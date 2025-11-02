namespace Lab_7;

public static class ConfigA
{
    public static void Configure(Injector injector)
    {
        Dictionary<string, object> class2DubugParameters = new();
        class2DubugParameters["Attribute1"] = new object();
        class2DubugParameters["Attribute2"] = new object();
        
        injector.Register<IInterface1, Class1Debug>(LifeStyle.Singleton);
        injector.Register<IInterface2, Class2Debug>(LifeStyle.Scoped, class2DubugParameters);
        injector.Register<IInterface3, Class3Debug>(LifeStyle.PerRequest);
    }
}