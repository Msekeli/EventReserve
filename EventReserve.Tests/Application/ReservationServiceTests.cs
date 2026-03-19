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
        var repoMock = new Mock<IReservationRepository>();
        var service = new ReservationService(repoMock.Object);

        var id = await service.CreateAsync("Derz", "Tech Summit", DateTime.UtcNow);

        repoMock.Verify(r => r.AddAsync(It.IsAny<Reservation>()), Times.Once);
        id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public async Task UpdateAsync_Should_Throw_When_Not_Found()
    {
        var repoMock = new Mock<IReservationRepository>();
        repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Reservation?)null);

        var service = new ReservationService(repoMock.Object);

        Func<Task> act = async () =>
            await service.UpdateAsync(Guid.NewGuid(), "Derz", "Tech Summit", DateTime.UtcNow);

        await act.Should().ThrowAsync<InvalidOperationException>();
    }
}