namespace AuthenticationServer.Models;

public class AuthenticationModel
{

    public required string Email { get; set; }
    public required string Password { get; set; }

    public AuthenticationModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

}

