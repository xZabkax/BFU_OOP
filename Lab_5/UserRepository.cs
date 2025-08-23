namespace Lab_5;

public class UserRepository : DataRepository<User>, IUserRepository
{
    public UserRepository(string filePath) : base(filePath) { }
    
    public User? GetByLogin(string login)
    {
        return _items.FirstOrDefault(user => user.Login == login);
    }
}