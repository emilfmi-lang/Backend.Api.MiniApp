using Backend.MiniApp.Api.Models.Common;

namespace Backend.MiniApp.Api.Models;

public class Performer:BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Occupation { get; set; } 

    public List<EventPerformer> EventPerformers { get; set; }
}
