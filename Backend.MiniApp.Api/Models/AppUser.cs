using Microsoft.AspNetCore.Identity;

namespace Backend.MiniApp.Api.Models;

public class AppUser: IdentityUser
{
    public string FullName { get; set; }
}
