using Backend.MiniApp.Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Backend.MiniApp.Api.Dtos.Organizers;

public class OrganizerCreateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string LogoUrl { get; set; }
}
public class UploadOrganizerLogoDto
{
    [Required]
    [FileType(new string[] { ".jpg", ".jpeg", ".png" })]
    [FileLength(2 * 1024 * 1024)] // 2 MB
    public string LogoUrl { get; set; }
}
