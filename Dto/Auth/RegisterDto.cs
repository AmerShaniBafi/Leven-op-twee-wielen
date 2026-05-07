namespace O2W.Dtos.Auth;

public class RegisterDto
{
    public string Naam { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string Stad { get; set; }
    public string Land { get; set; }
    public DateTime Geboortedatum { get; set; }
}