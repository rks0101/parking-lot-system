using Microsoft.AspNetCore.Mvc;
using ParkingLot.BAL.Services;
using ParkingLot.Domain.Entities;

namespace ParkingLot.Api.Controllers;

[ApiController]
[Route("api/slots")]
public class ParkingSlotsController : ControllerBase
{
    private readonly IParkingSlotService _service;

    public ParkingSlotsController(IParkingSlotService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var slot = await _service.GetByIdAsync(id);
        return slot != null ? Ok(slot) : NotFound();
    }

    [HttpGet("slot/{slotNumber}")]
    public async Task<IActionResult> GetBySlotNumber(string slotNumber)
    {
        var slot = await _service.GetBySlotNumberAsync(slotNumber);
        return slot != null ? Ok(slot) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ParkingSlot slot)
        => Ok(await _service.CreateSlotAsync(slot));

    [HttpPut("{id}/occupy")]
    public async Task<IActionResult> MarkAsOccupied(int id)
    {
        var result = await _service.MarkSlotAsOccupiedAsync(id);
        return result ? Ok() : BadRequest();
    }

    [HttpPut("{id}/available")]
    public async Task<IActionResult> MarkAsAvailable(int id)
    {
        var result = await _service.MarkSlotAsAvailableAsync(id);
        return result ? Ok() : BadRequest();
    }
}