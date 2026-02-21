using EventReserve.Domain.Entities;

namespace EventReserve.Application.Interfaces;

public interface IReservationRepository
{
    Task AddAsync(Reservation reservation);
    Task<Reservation?> GetByIdAsync(Guid id);
    Task UpdateAsync(Reservation reservation);
    Task DeleteAsync(Guid id);
}