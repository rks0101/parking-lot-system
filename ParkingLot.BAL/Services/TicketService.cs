using ParkingLot.DAL.Repositories;
using ParkingLot.Domain.Entities;
namespace ParkingLot.BAL.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _repo;

    public TicketService(ITicketRepository repo)
    {
        _repo = repo;
    }

    public async Task<Ticket?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task<Ticket?> GetByTicketNoAsync(string ticketNo) => await _repo.GetByTicketNoAsync(ticketNo);
    public async Task<List<Ticket>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        await _repo.AddAsync(ticket);
        await _repo.SaveChangesAsync();
        return ticket;
    }
}