namespace Lab_4;

public abstract class Observable<T> : INotifyDataChanged<T>, INotifyDataChanging<T>
{
    private readonly HashSet<IPropertyChangedListener<T>> _propertyChangedListeners = new();
    private readonly HashSet<IPropertyChangingListener<T>> _propertyChangingListeners = new();

    public void AddPropertyChangedListeners(params IPropertyChangedListener<T>[] listeners)
    {
        foreach (var listener in listeners)
        {
            _propertyChangedListeners.Add(listener);
        }
    }

    public void RemovePropertyChangedListeners(params IPropertyChangedListener<T>[] listeners)
    {
        foreach (var listener in listeners)
        {
            _propertyChangedListeners.Remove(listener);
        }
    }

    public void AddPropertyChangingListeners(params IPropertyChangingListener<T>[] listeners)
    {
        foreach (var validator in listeners)
        {
            _propertyChangingListeners.Add(validator);
        }
    }

    public void RemovePropertyChangingListeners(params IPropertyChangingListener<T>[] listeners)
    {
        foreach (var validator in listeners)
        {
            _propertyChangingListeners.Remove(validator);
        }
    }

    public void NotifyPropertyChanged(T obj, string propertyName)
    {
        foreach (var listener in _propertyChangedListeners)
        {
            listener.OnPropertyChanged(obj, propertyName);
        }
    }

    public bool NotifyPropertyChanging(T obj, string propertyName, object oldValue, object newValue)
    {
        return _propertyChangingListeners.All(validator =>
            validator.OnPropertyChanging(obj, propertyName, oldValue, newValue));
    }
}