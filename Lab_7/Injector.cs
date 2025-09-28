namespace Lab_7;

public class Injector
{
    private class Registration
    {
        public Func<object> Factory;
        public LifeStyle LifeStyle;
        public object SingletonInstance;
        public Dictionary<string, object> Parameters;
    }

    private readonly Dictionary<Type, Registration> _registrations = new();
    private readonly Stack<Scope> _scopes = new();

    public void Register<TInterface, TClass>(LifeStyle lifeStyle, Dictionary<string, object> parameters = null)
        where TClass : TInterface
    {
        _registrations[typeof(TInterface)] = new Registration
        {
            Factory = () => CreateInstance(typeof(TClass), parameters),
            LifeStyle = lifeStyle,
            Parameters = parameters
        };
    }

    public void Register<TInterface>(Func<object> factoryMethod)
    {
        _registrations[typeof(TInterface)] = new Registration
        {
            Factory = factoryMethod,
            LifeStyle = LifeStyle.PerRequest
        };
    }

    private object CreateInstance(Type type, Dictionary<string, object> parameters)
    {
        var ctor = type.GetConstructors().First();
        var args = ctor.GetParameters().Select(p =>
        {
            if (parameters != null && parameters.TryGetValue(p.Name, out var val))
                return val;
            return GetInstance(p.ParameterType);
        }).ToArray();

        return Activator.CreateInstance(type, args);
    }

    public object GetInstance(Type interfaceType)
    {
        if (!_registrations.TryGetValue(interfaceType, out var reg))
            throw new InvalidOperationException($"Type {interfaceType} not registered.");

        return reg.LifeStyle switch
        {
            LifeStyle.Singleton => reg.SingletonInstance ??= reg.Factory(),
            LifeStyle.Scoped when _scopes.Any() =>
                _scopes.Peek().ScopedInstances.TryGetValue(interfaceType, out var inst)
                ? inst
                : (_scopes.Peek().ScopedInstances[interfaceType] = reg.Factory()),
            _ => reg.Factory()
        };
    }

    public T GetInstance<T>() => (T)GetInstance(typeof(T));

    internal void PushScope(Scope scope) => _scopes.Push(scope);
    internal void PopScope() => _scopes.Pop();
}

public enum LifeStyle
{
    PerRequest,
    Scoped,
    Singleton
}

public class Scope : IDisposable
{
    private readonly Injector _injector;
    internal Dictionary<Type, object> ScopedInstances = new();

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