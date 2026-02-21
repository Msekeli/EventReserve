using EventReserve.Application.Interfaces;
using EventReserve.Domain.Entities;

namespace EventReserve.Infrastructure.Repositories;

public class InMemoryReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = new();

    public Task AddAsync(Reservation reservation)
    {
        _reservations.Add(reservation);
        return Task.CompletedTask;
    }

    public Task<Reservation?> GetByIdAsync(Guid id)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(reservation);
    }

    public Task UpdateAsync(Reservation reservation)
    {
        // Since the object is already tracked in memory,
        // no additional work is required.
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == id);

        if (reservation != null)
            _reservations.Remove(reservation);

        return Task.CompletedTask;
    }
}