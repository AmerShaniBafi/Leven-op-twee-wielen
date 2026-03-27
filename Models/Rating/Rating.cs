namespace O2W.Models.Rating;

public class Rating
{
    public int Id { get; set; }
    public int AantalSterren { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Opmerking { get; set; }

    public int RouteId { get; set; }
    public Microsoft.AspNetCore.Routing.Route Route { get; set; }

    public int UserId { get; set; }
    public User.User User { get; set; }
}