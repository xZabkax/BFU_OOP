namespace Lab_4;

public interface INotifyDataChanging
{
    void AddPropertyChangingListener(IPropertyChangingListener listener);
    void RemovePropertyChangingListener(IPropertyChangingListener listener);
}