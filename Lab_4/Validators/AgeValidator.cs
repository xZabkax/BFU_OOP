namespace Lab_4;

public class AgeValidator : IPropertyChangingListener<User>
{
    public bool OnPropertyChanging(User obj, string propertyName, object oldValue, object newValue)
    {
        if (nameof(obj.Age) != propertyName) return true; // Значит observable пытается изменить другое своё поле
        if (newValue is not int age) return false;

        if (age is <= 0 or > 100)
        {
            Console.WriteLine("Error: Possible age is from 0 to 100 years");
            return false;
        }
        
        return true;
    }
}