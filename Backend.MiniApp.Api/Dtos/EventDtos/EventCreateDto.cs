namespace Backend.MiniApp.Api.Dtos.EventDtos;

public class EventCreateDto
{
    public string Title { get; set; }   
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Location { get; set; }
    public string BannerImageUrl { get; set; }
}
