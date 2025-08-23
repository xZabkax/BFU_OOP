namespace Lab_5;

public interface IAuthService
{
    void SignIn(User user);
    void SignOut(User user);
    protected bool IsAuthorized { get; }
    protected User? CurrentUser { get; }
}