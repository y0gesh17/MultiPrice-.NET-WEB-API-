using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

public class RegisterModel
{

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string ConfirmPassword { get; set; }

    public string [] Role { get; set; }
}
