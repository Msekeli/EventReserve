using EventReserve.Domain.Entities;

namespace EventReserve.Application.Interfaces;

public interface IReservationRepository
{
    Task<List<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(Guid id);
    Task AddAsync(Reservation reservation);
    Task UpdateAsync(Reservation reservation);
    Task DeleteAsync(Guid id);
}