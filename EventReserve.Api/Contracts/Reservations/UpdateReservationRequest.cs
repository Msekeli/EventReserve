namespace EventReserve.Api.Contracts.Reservations;

public class UpdateReservationRequest
{
    public string AttendeeName { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
}