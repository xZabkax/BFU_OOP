namespace Lab_5;

public interface IAuthService
{
    void SignIn(User user);
    void SignOut();
    bool IsAuthorized { get; }
    User? CurrentUser { get; }
}