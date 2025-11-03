namespace Lab_7;

public class Injector
{
    private readonly Dictionary<Type, Registration> _registrations = new();
    private readonly Dictionary<Type, object> _singletons = new();
    private readonly Stack<Scope> _scopes = new();

    public void Register<TInterface, TClass>(LifeStyle lifeStyle, Dictionary<string, object> parameters = null)
        where TClass : TInterface
    {
        _registrations[typeof(TInterface)] = new Registration(
            factory: () => CreateInstance(typeof(TClass), parameters),
            lifeStyle: lifeStyle);
    }

    public void Register<TInterface>(Func<object> factory, LifeStyle lifeStyle)
    {
        _registrations[typeof(TInterface)] = new Registration(
            factory,
            lifeStyle);
    }

    public TInterface GetInstance<TInterface>() where TInterface : class
    {
        return (TInterface)GetInstance(typeof(TInterface));
    }

    public object GetInstance(Type interfaceType)
    {
        if (!_registrations.TryGetValue(interfaceType, out var registration))
        {
            throw new ArgumentException($"Type {interfaceType} not registered.");
        }
        
        object instance;
        switch (registration.LifeStyle)
        {
            case LifeStyle.Scoped:
                if (_scopes.Any())
                {
                    var scope = _scopes.Peek();
                    if (!scope.Instances.TryGetValue(interfaceType, out object? scopeInstance))
                    {
                        scopeInstance = registration.Factory.Invoke();
                        scope.Instances[interfaceType] = scopeInstance;
                    }

                    instance = scopeInstance;
                    break;
                }
                instance = registration.Factory.Invoke();
                break;
            case LifeStyle.Singleton:
                if (!_singletons.TryGetValue(interfaceType, out object? value))
                {
                    value = registration.Factory.Invoke();
                    _singletons[interfaceType] = value;
                }
                instance = value;
                break;
            case LifeStyle.PerRequest:
            default:
                instance = registration.Factory.Invoke();
                break;
                
        }
        return instance;
    }

    private object CreateInstance(Type classType, Dictionary<string, object> parameters)
    {
        var constructors = classType.GetConstructors();
        foreach (var constructor in constructors)
        {
            var parameterInfos = constructor.GetParameters();
            if (parameterInfos.Length == 0)
            {
                var incomingParametersCount = parameters?.Count ?? 0;
                
                if (incomingParametersCount > 0)
                {
                    continue;
                }
                if (incomingParametersCount == 0)
                {
                    return Activator.CreateInstance(classType);
                }
            }
            
            var args = new List<object>();
            bool suitable = true;
            
            foreach (var parameterInfo in parameterInfos)
            {
                if (parameters != null && parameters.TryGetValue(parameterInfo.Name, out var val))
                {
                    args.Add(val);
                }
                else if (_registrations.ContainsKey(parameterInfo.ParameterType))
                {
                    args.Add(GetInstance(parameterInfo.ParameterType));
                }
                else if (!parameterInfo.IsOptional)
                {
                    suitable = false;
                    break;
                }
            }

            if (!suitable)
            {
                continue;
            }

            if (args.Count > 0)
            {
                return Activator.CreateInstance(classType, args.ToArray()); //Рефлексия
            }
            else
            {
                return Activator.CreateInstance(classType);
            }
            
        }

        throw new ArgumentException($"Failed to create instance of type {classType}: inappropriate parameters");
    }

    public void PushScope(Scope scope)
    {
        _scopes.Push(scope);
    }

    public void PopScope()
    {
        _scopes.Pop();
    }
    
    private record Registration
    {
        public LifeStyle LifeStyle { get; }
        public Func<object> Factory { get; }

        public Registration(Func<object> factory, LifeStyle lifeStyle)
        {
            Factory = factory;
            LifeStyle = lifeStyle;
        }
    }
}