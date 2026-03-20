namespace EventReserve.Api.Contracts.Reservations;

public sealed class ReservationResponse
{
    public Guid Id { get; set; }
    public string AttendeeName { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
}