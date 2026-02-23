using Microsoft.AspNetCore.Mvc;
using ParkingLot.BAL.Services;
using ParkingLot.Domain.Entities;

namespace ParkingLot.Api.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _service;

    public PaymentsController(IPaymentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var payment = await _service.GetByIdAsync(id);
        return payment != null ? Ok(payment) : NotFound();
    }

    [HttpGet("ticket/{ticketId}")]
    public async Task<IActionResult> GetByTicketId(int ticketId)
    {
        var payment = await _service.GetByTicketIdAsync(ticketId);
        return payment != null ? Ok(payment) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Payment payment)
        => Ok(await _service.CreatePaymentAsync(payment));
}