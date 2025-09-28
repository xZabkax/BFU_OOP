using System.Text.Json.Serialization;

namespace Lab_5;

public record User : IComparable<User>
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Login { get; init; }
    [JsonIgnore] public string Password { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public int CompareTo(User? other)
    {
        return other == null ? 1 : Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
        return $"User(Id: {Id}, Name: {Name}, Login: {Login}, Email: {Email ?? "N/A"}, Address: {Address ?? "N/A"})";
    }
}
