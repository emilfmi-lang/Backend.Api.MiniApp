using Backend.MiniApp.Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Backend.MiniApp.Api.Dtos.EventDtos;

public class EventReturnDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Location { get; set; }
    public string BannerImageUrl { get; set; }
}
public class UploadEventBannerDto
{
    [Required]
    [FileType(new string[] { ".jpg", ".jpeg", ".png" })]
    [FileLength(2 * 1024 * 1024)] // 2MB
    public IFormFile File { get; set; } = null!;
}
