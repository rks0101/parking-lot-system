using Microsoft.AspNetCore.Mvc;
using ParkingLot.BAL.Services;
using ParkingLot.Domain.Entities;

namespace ParkingLot.Api.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _service;

    public TicketsController(ITicketService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await _service.GetByIdAsync(id);
        return ticket != null ? Ok(ticket) : NotFound();
    }

    [HttpGet("ticket/{ticketNo}")]
    public async Task<IActionResult> GetByTicketNo(string ticketNo)
    {
        var ticket = await _service.GetByTicketNoAsync(ticketNo);
        return ticket != null ? Ok(ticket) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Ticket ticket)
        => Ok(await _service.CreateTicketAsync(ticket));
}