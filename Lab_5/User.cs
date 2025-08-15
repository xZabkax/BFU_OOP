namespace Lab_5;

public record User()
{
    private int id;
    private string name;
    private string login;
    private string password;
    private string email;
    private string address;
    
    //TODO - Сделать, чтобы коллекция классов User умела сортироваться по полю name.
    //TODO Реализовать через dataclass или через аналоги в других языках (C# и Java: record)
}
