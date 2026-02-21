namespace EventReserve.Domain.Entities;

public sealed class Reservation
{
    public Guid Id { get; private set; }
    public string AttendeeName { get; private set; }
    public string EventName { get; private set; }
    public DateTime EventDate { get; private set; }

    private Reservation()
{
    AttendeeName = null!;
    EventName = null!;
}// For potential future persistence

    public Reservation(Guid id, string attendeeName, string eventName, DateTime eventDate)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));

        if (string.IsNullOrWhiteSpace(attendeeName))
            throw new ArgumentException("Attendee name is required.", nameof(attendeeName));

        if (string.IsNullOrWhiteSpace(eventName))
            throw new ArgumentException("Event name is required.", nameof(eventName));

        Id = id;
        AttendeeName = attendeeName;
        EventName = eventName;
        EventDate = eventDate;
    }

    public void Update(string attendeeName, string eventName, DateTime eventDate)
    {
        if (string.IsNullOrWhiteSpace(attendeeName))
            throw new ArgumentException("Attendee name is required.", nameof(attendeeName));

        if (string.IsNullOrWhiteSpace(eventName))
            throw new ArgumentException("Event name is required.", nameof(eventName));

        AttendeeName = attendeeName;
        EventName = eventName;
        EventDate = eventDate;
    }
}