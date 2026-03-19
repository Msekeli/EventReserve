using EventReserve.Api.Contracts.Reservations;
using EventReserve.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventReserve.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly ReservationService _service;

    public ReservationsController(ReservationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReservationResponse>>> GetAll()
    {
        var reservations = await _service.GetAllAsync();

        var response = reservations
            .Select(r => new ReservationResponse
            {
                Id = r.Id,
                AttendeeName = r.AttendeeName,
                EventName = r.EventName,
                EventDate = r.EventDate
            })
            .ToList();

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReservationResponse>> GetById(Guid id)
    {
        var reservation = await _service.GetByIdAsync(id);

        if (reservation is null)
            return NotFound();

        var response = new ReservationResponse
        {
            Id = reservation.Id,
            AttendeeName = reservation.AttendeeName,
            EventName = reservation.EventName,
            EventDate = reservation.EventDate
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateReservationRequest request)
    {
        var id = await _service.CreateAsync(
            request.AttendeeName,
            request.EventName,
            request.EventDate);

        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReservationRequest request)
    {
        try
        {
            await _service.UpdateAsync(
                id,
                request.AttendeeName,
                request.EventName,
                request.EventDate);

            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}