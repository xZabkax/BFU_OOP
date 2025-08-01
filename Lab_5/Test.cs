namespace Lab_5;

public class Test : IAuthService
{
    //Создать реализацию IAuthService / AuthServiceProtocol, которая хранит информацию о текущем пользователе в файле
    //и автоматически авторизует пользователя при повторном заходе в программу в случае наличия соответствующей записи
    //в файле
    
    public void SignIn(User user)
    {
        throw new NotImplementedException();
    }

    public void SignOut(User user)
    {
        throw new NotImplementedException();
    }

    public bool IsAuthorized()
    {
        throw new NotImplementedException();
    }

    public User CurrentUser()
    {
        throw new NotImplementedException();
    }
}