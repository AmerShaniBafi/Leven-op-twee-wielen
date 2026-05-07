namespace O2W.DTOs.User;

public class UserDto
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public DateTime Geboortedatum { get; set; }
    public string Stad { get; set; }
    public string Land { get; set; }
    public string Email { get; set; }
    public string WachtwoordHash { get; set; }

}