using Lab_5;

var user1 = new User(){Id = 1, Login = "Jojo", Password = "123", Name = "Jotaro"};
var user2 = new User(){Id = 2, Login = "Vampire", Password = "456", Name = "Dio"};
var user3 = new User(){Id = 3, Login = "Pop", Password = "789", Name = "Iggy"};
var user4 = new User(){Id = 4, Login = "Cow", Password = "101", Name = "Holy"};

var users = new List<User>{/*user1, user2, user3, user4*/};
users.Sort();

foreach (var user in users)
{
    Console.WriteLine(user.Name);
}
