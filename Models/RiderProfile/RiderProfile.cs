namespace O2W.Models.RiderProfile;

public class RiderProfile
{
    public int Id { get; set; }
    public string Ervaringsniveau { get; set; }
    public decimal FavorieteRitafstand { get; set; }
    public bool SnelwegenVermijden { get; set; }
    public string TypeRit { get; set; }

    public int UserId { get; set; }
    public User.User User { get; set; }
}