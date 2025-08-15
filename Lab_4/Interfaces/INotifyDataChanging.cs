namespace Lab_4;

public interface INotifyDataChanging<T>
{
    void AddPropertyChangingListeners(params IPropertyChangingListener<T>[] listeners);
    void RemovePropertyChangingListeners(params IPropertyChangingListener<T>[] listeners);
    public bool NotifyPropertyChanging(T obj, string propertyName, object oldValue, object newValue);

}