using Lab_5;

try
{
    var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
    Directory.SetCurrentDirectory(dir.Parent.Parent.Parent.FullName);
}
catch
{
    Console.WriteLine("Couldn't set a new working directory");
    throw;
}
finally
{
    Console.WriteLine("Current working directory: " + Directory.GetCurrentDirectory() +  "\n");
}

var userRepo = new UserRepository(@"res\users.json");
var authService = new AuthService(userRepo, @"res\auth.json");

var user1 = new User{Id = 1, Login = "Jojo", Password = "123", Name = "Jotaro"};
var user2 = new User{Id = 2, Login = "Vampire", Password = "456", Name = "Dio"};
var user3 = new User{Id = 3, Login = "Pop", Password = "789", Name = "Iggy"};
var user4 = new User{Id = 4, Login = "Cow", Password = "101", Name = "Holy"};

if (authService.IsAuthorized)
{
    Console.WriteLine($"Автоматически авторизован пользователь: {authService.CurrentUser}");
}

userRepo.Add(user1, user2, user3, user4);

authService.SignIn(user1);
Console.WriteLine($"\nПользователь авторизован: {authService.CurrentUser}");

var updatedUser1 = user1 with {Email = "example@mail.ru"};
userRepo.Update(updatedUser1);
Console.WriteLine($"\nДанные пользователя {userRepo.GetById(updatedUser1.Id)} обновлены: ");

var login = "Jojo";
var findUser = userRepo.GetByLogin(login);
Console.WriteLine($"\nПоиск пользователя по логину \"{login}\": {userRepo.GetByLogin(login)}");

List<User> users = new List<User>{ user1, user2, user3, user4 };
users.Sort();

foreach (var user in users)
{
    Console.WriteLine(user);
}
