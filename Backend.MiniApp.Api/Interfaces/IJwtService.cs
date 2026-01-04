using Backend.MiniApp.Api.Models;

namespace Backend.MiniApp.Api.Interfaces;

public interface IJwtService
{
    string GenerateTokenAsync(AppUser user, IList<string> roles);
}
