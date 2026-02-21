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

    [HttpPost]
    public async Task<IActionResult> Create(string attendeeName, string eventName, DateTime eventDate)
    {
        var id = await _service.CreateAsync(attendeeName, eventName, eventDate);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, string attendeeName, string eventName, DateTime eventDate)
    {
        await _service.UpdateAsync(id, attendeeName, eventName, eventDate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}