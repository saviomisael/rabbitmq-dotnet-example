namespace ConsumerExample;

public class User
{
    public string Email { get; }
    public string Username { get; }

    public User(string email, string username)
    {
        Email = email;
        Username = username;
    }
}