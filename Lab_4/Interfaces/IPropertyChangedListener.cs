namespace Lab_4;

public interface IPropertyChangedListener<T>
{
    void OnPropertyChanged(T obj ,string propertyName);
}