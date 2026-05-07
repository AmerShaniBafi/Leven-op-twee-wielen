using O2W.Models.EventRegistrations;
namespace O2W.Models.User;

public class User
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public DateTime Geboortedatum { get; set; }
    public string Stad { get; set; }
    public string Land { get; set; }
    public string Email { get; set; }
    public string WachtwoordHash { get; set; }

    // Relaties
    public RiderProfile.RiderProfile RiderProfile { get; set; }
    public ICollection<MotorRoute.MotorRoute> MotorRoute { get; set; }
    public ICollection<Rating.Rating> Ratings { get; set; }
    public ICollection<EventRegistration> EventRegistrations { get; set; }
    public ICollection<Event.Event> CreatedEvents { get; set; }
}