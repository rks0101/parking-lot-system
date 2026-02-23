using Microsoft.AspNetCore.Mvc;
using ParkingLot.BAL.Services;
using ParkingLot.Domain.Entities;

namespace ParkingLot.Api.Controllers;

[ApiController]
[Route("api/vehicles")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _service;

    public VehiclesController(IVehicleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vehicle = await _service.GetByIdAsync(id);
        return vehicle != null ? Ok(vehicle) : NotFound();
    }

    [HttpGet("plate/{plateNumber}")]
    public async Task<IActionResult> GetByPlate(string plateNumber)
    {
        var vehicle = await _service.GetByPlateAsync(plateNumber);
        return vehicle != null ? Ok(vehicle) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Register(Vehicle vehicle)
        => Ok(await _service.RegisterVehicleAsync(vehicle));
}