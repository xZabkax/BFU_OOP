namespace Lab_5;

public interface IUserRepository
{
    User? GetByLogin(string login);
}