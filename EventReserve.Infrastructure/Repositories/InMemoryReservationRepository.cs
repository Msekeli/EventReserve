using EventReserve.Application.Interfaces;
using EventReserve.Domain.Entities;

namespace EventReserve.Infrastructure.Repositories;

public class InMemoryReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations;

    public InMemoryReservationRepository()
    {
        _reservations = new List<Reservation>
        {
            new(Guid.NewGuid(), "John Doe", "Tech Conference", DateTime.UtcNow.AddDays(5)),
            new(Guid.NewGuid(), "Jane Smith", "Music Festival", DateTime.UtcNow.AddDays(8)),
            new(Guid.NewGuid(), "Michael Brown", "Startup Expo", DateTime.UtcNow.AddDays(12)),
            new(Guid.NewGuid(), "Emily Johnson", "Art Showcase", DateTime.UtcNow.AddDays(15)),
            new(Guid.NewGuid(), "David Wilson", "Business Summit", DateTime.UtcNow.AddDays(18)),
            new(Guid.NewGuid(), "Sarah Lee", "Food Fair", DateTime.UtcNow.AddDays(22)),
            new(Guid.NewGuid(), "Chris Evans", "Fitness Workshop", DateTime.UtcNow.AddDays(25)),
            new(Guid.NewGuid(), "Olivia Taylor", "Fashion Expo", DateTime.UtcNow.AddDays(28)),
            new(Guid.NewGuid(), "Daniel Martinez", "Gaming Convention", DateTime.UtcNow.AddDays(32)),
            new(Guid.NewGuid(), "Sophia Anderson", "Film Premiere", DateTime.UtcNow.AddDays(35))
        };
    }

    public Task<List<Reservation>> GetAllAsync()
    {
        return Task.FromResult(_reservations.ToList());
    }

    public Task<Reservation?> GetByIdAsync(Guid id)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(reservation);
    }

    public Task AddAsync(Reservation reservation)
    {
        _reservations.Add(reservation);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Reservation reservation)
    {
        var existing = _reservations.FirstOrDefault(r => r.Id == reservation.Id);

        if (existing is not null)
        {
            existing.Update(
                reservation.AttendeeName,
                reservation.EventName,
                reservation.EventDate);
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == id);

        if (reservation is not null)
        {
            _reservations.Remove(reservation);
        }

        return Task.CompletedTask;
    }
}