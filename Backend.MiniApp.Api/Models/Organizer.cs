using Backend.MiniApp.Api.Models.Common;

namespace Backend.MiniApp.Api.Models;

public class Organizer: BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string LogoUrl { get; set; }

}
