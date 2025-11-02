namespace Lab_7;

public class Scope : IDisposable
{
    private Injector _injector;
    public Dictionary<Type, object> Instances = new();

    public Scope(Injector injector)
    {
        _injector = injector;
        _injector.PushScope(this);
    }

    public void Dispose()
    {
        _injector.PopScope();
    }
}