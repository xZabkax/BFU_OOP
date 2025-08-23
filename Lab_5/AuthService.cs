namespace Lab_5;

public class AuthService : IAuthService
{
    private readonly string _filePath;
    private IUserRepository _userRepository;

    public bool IsAuthorized => CurrentUser is not null;
    public User? CurrentUser { get; private set; }


    public AuthService(string filePath)
    {
        _filePath = filePath;
    }

    public void SignIn(User user)
    {
        CurrentUser = user;
        SaveSession();
    }
    

    public void SignOut(User user)
    {
        throw new NotImplementedException();
    }
    
    private void SaveSession()
    {
        throw new NotImplementedException();
    }

    
}