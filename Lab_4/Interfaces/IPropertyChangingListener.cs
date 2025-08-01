namespace Lab_4;

public interface IPropertyChangingListener
{
    bool OnPropertyChanging(Object T, string propertyName, int oldValue, int newValue);
}