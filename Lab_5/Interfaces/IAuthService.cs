namespace Lab_5;

public interface IAuthService
{
    void SignIn(User user);
    void SignOut(User user);
    bool IsAuthorized();
    User CurrentUser();
}