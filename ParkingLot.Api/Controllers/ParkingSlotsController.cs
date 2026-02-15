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
        => Ok(await _service.GetSlotsAsync());

    [HttpPost]
    public async Task<IActionResult> Create(ParkingSlot slot)
        => Ok(await _service.CreateSlotAsync(slot));
}