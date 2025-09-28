using System.Text.Json;

namespace Lab_5;

public class AuthService : IAuthService
{
    private readonly string _authFilePath;
    private readonly IUserRepository _userRepository;

    public bool IsAuthorized => CurrentUser is not null;
    public User? CurrentUser { get; private set; }


    public AuthService(IUserRepository userRepository, string authFilePath)
    {
        _userRepository = userRepository;
        _authFilePath = authFilePath;
        CurrentUser = LoadSavedUser();
    }

    public void SignIn(User user)
    {
        CurrentUser = user;
        SaveCurrentUser(user);
        Console.WriteLine($"Авторизован пользователь {user.Name}");
    }
    
    public void SignOut()
    {
        CurrentUser = null;
        ClearSavedUser();
    }

    private void SaveCurrentUser(User user)
    {
        try
        {
            var json = JsonSerializer.Serialize(user.Id);
            File.WriteAllText(_authFilePath, json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private User? LoadSavedUser()
    {
        if (!File.Exists(_authFilePath))
            return null;

        try
        {
            var json = File.ReadAllText(_authFilePath);
            return _userRepository.GetById(JsonSerializer.Deserialize<int>(json));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void ClearSavedUser()
    {
        if (!File.Exists(_authFilePath)) return;
        try
        {
            File.Delete(_authFilePath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}