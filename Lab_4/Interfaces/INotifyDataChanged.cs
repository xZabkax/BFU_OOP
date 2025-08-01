namespace Lab_4;

public interface INotifyDataChanged
{
    void AddPropertyChangedListener(IPropertyChangedListener listener);
    void RemovePropertyChangedListener(IPropertyChangedListener listener);
}