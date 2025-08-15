namespace Lab_4;

// Имитируем класс абстрактного пользователя
public class User : Observable<User>
{
    private string _name;
    private int _age;
    
    public string Name
    {
        get => _name;
        set
        {
            if (NotifyPropertyChanging(this, nameof(Name), _name, value))
            {
                _name = value;
            }
            else
            {
                Console.WriteLine("The change was rejected");
            }
            
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (NotifyPropertyChanging(this, nameof(Age), _age, value))
            {
                _age = value;
            }
            else
            {
                Console.WriteLine("The change was rejected");
            }
            
        }
    }
}