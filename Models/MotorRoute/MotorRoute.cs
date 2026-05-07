namespace O2W.Models.MotorRoute;
public class MotorRoute
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public string Beschrijving { get; set; }
    public string Startlocatie { get; set; }
    public string Eindlocatie { get; set; }
    public string KaartUrl { get; set; }
    public bool IsPublic { get; set; }
    public decimal AfstandKm { get; set; }
    public TimeOnly GeschatteReistijd { get; set; }
    public string Moeilijkheidsgraad { get; set; }
    public string RouteType { get; set; }
    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }
    public User.User User { get; set; }

    public ICollection<Rating.Rating> Ratings { get; set; }
}