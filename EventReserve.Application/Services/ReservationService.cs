using EventReserve.Application.Interfaces;
using EventReserve.Domain.Entities;

namespace EventReserve.Application.Services;

public class ReservationService
{
    private readonly IReservationRepository _repository;

    public ReservationService(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(string attendeeName, string eventName, DateTime eventDate)
    {
        var reservation = new Reservation(
            Guid.NewGuid(),
            attendeeName,
            eventName,
            eventDate);

        await _repository.AddAsync(reservation);

        return reservation.Id;
    }

    public async Task UpdateAsync(Guid id, string attendeeName, string eventName, DateTime eventDate)
    {
        var existing = await _repository.GetByIdAsync(id);

        if (existing is null)
            throw new InvalidOperationException("Reservation not found.");

        existing.Update(attendeeName, eventName, eventDate);

        await _repository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}