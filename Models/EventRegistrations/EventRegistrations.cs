namespace O2W.Models.EventRegistrations;

public class EventRegistration
{
    public int Id { get; set; }
    public DateTime RegisteredAt { get; set; }

    public int UserId { get; set; }
    public User.User User { get; set; }

    public int EventId { get; set; }
    public Event.Event Event { get; set; }
}