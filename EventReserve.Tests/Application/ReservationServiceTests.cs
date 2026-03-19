using EventReserve.Application.Interfaces;
using EventReserve.Application.Services;
using EventReserve.Domain.Entities;
using FluentAssertions;
using Moq;
namespace EventReserve.Tests.Application;

public class ReservationServiceTests
{
    [Fact]
    public async Task CreateAsync_Should_Call_AddAsync_On_Repository()
    {
        // Arrange
        var repoMock = new Mock<IReservationRepository>();
        var service = new ReservationService(repoMock.Object);
        var attendeeName = "Derz";
        var eventName = "Tech Summit";
        var eventDate = DateTime.UtcNow;

        // Act
        var id = await service.CreateAsync(attendeeName, eventName, eventDate);

        // Assert
        id.Should().NotBe(Guid.Empty);

        repoMock.Verify(r => r.AddAsync(It.Is<Reservation>(reservation =>
            reservation.Id == id &&
            reservation.AttendeeName == attendeeName &&
            reservation.EventName == eventName &&
            reservation.EventDate == eventDate
        )), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_Should_Throw_When_Reservation_Not_Found()
    {
        // Arrange
        var repoMock = new Mock<IReservationRepository>();
        repoMock
            .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Reservation?)null);

        var service = new ReservationService(repoMock.Object);

        // Act
        Func<Task> act = async () =>
            await service.UpdateAsync(Guid.NewGuid(), "Derz", "Tech Summit", DateTime.UtcNow);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Reservation not found.");
    }

    [Fact]
    public async Task UpdateAsync_Should_Call_UpdateAsync_On_Repository_When_Reservation_Exists()
    {
        // Arrange
        var repoMock = new Mock<IReservationRepository>();
        var reservationId = Guid.NewGuid();
        var existingReservation = new Reservation(
            reservationId,
            "Old Name",
            "Old Event",
            DateTime.UtcNow.AddDays(1));

        repoMock
            .Setup(r => r.GetByIdAsync(reservationId))
            .ReturnsAsync(existingReservation);

        var service = new ReservationService(repoMock.Object);

        var updatedAttendeeName = "Derz";
        var updatedEventName = "Tech Summit";
        var updatedEventDate = DateTime.UtcNow.AddDays(5);

        // Act
        await service.UpdateAsync(
            reservationId,
            updatedAttendeeName,
            updatedEventName,
            updatedEventDate);

        // Assert
        repoMock.Verify(r => r.UpdateAsync(It.Is<Reservation>(reservation =>
            reservation.Id == reservationId &&
            reservation.AttendeeName == updatedAttendeeName &&
            reservation.EventName == updatedEventName &&
            reservation.EventDate == updatedEventDate
        )), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_Should_Call_DeleteAsync_On_Repository()
    {
        // Arrange
        var repoMock = new Mock<IReservationRepository>();
        var service = new ReservationService(repoMock.Object);
        var reservationId = Guid.NewGuid();

        // Act
        await service.DeleteAsync(reservationId);

        // Assert
        repoMock.Verify(r => r.DeleteAsync(reservationId), Times.Once);
    }
}