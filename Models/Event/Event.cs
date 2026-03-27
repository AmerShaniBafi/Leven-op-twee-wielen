using O2W.Models.EventRegistrations;

namespace O2W.Models.Event;

public class Event
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public string Beschrijving { get; set; }
    public DateTime Datum { get; set; }
    public string Locatie { get; set; }
    public DateTime CreatedAt { get; set; }

    public int CreatedByUserId { get; set; }
    public User.User CreatedByUser { get; set; }

    public ICollection<EventRegistration> Registrations { get; set; }
}