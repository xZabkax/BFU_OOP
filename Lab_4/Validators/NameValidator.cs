namespace Lab_4;

public class NameValidator : IPropertyChangingListener<User>
{
    public bool OnPropertyChanging(User obj, string propertyName, object oldValue, object newValue)
    {
        if (nameof(obj.Name) != propertyName) return true; // Значит observable пытается изменить другое своё поле
        if (newValue is not string name) return false;
        
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: Name can't be empty!");
            return false;
        }

        if (name.Length > 50)
        {
            Console.WriteLine("Error: Max name length is 50 characters!");
            return false;
        }

        return true;
    }
}