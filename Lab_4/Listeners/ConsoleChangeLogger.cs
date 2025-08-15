namespace Lab_4;

public class ConsoleChangeLogger : IPropertyChangedListener<ObservableForDataChanged>
{
    public void OnPropertyChanged(ObservableForDataChanged obj, string propertyName)
    {
        Console.WriteLine($"[Change] The \"{propertyName}\" property has been changed in the [{obj}]. HashCode: {obj.GetHashCode()}");
    }
}