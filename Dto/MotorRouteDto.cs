namespace O2W.DTOs;

public class MotorRouteDto
{
    public string Titel { get; set; } = string.Empty;
    public string Beschrijving { get; set; } = string.Empty;
    public string Startlocatie { get; set; } = string.Empty;
    public string Eindlocatie { get; set; } = string.Empty;
    public string KaartUrl { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
    public decimal AfstandKm { get; set; }
    public TimeOnly GeschatteReistijd { get; set; }
    public string Moeilijkheidsgraad { get; set; } = string.Empty;
    public string RouteType { get; set; } = string.Empty;
    public int UserId { get; set; }
}