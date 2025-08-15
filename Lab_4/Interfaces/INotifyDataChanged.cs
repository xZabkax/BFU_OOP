namespace Lab_4;

public interface INotifyDataChanged<T>
{
    void AddPropertyChangedListeners(params IPropertyChangedListener<T>[] listeners);
    void RemovePropertyChangedListeners(params IPropertyChangedListener<T>[] listeners);
    void NotifyPropertyChanged(T obj, string propertyName);
}