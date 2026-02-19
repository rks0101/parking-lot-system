using Microsoft.EntityFrameworkCore;
using ParkingLot.Domain.Entities;
using ParkingLot.DAL.Data;
using ParkingLot.Domain.Enums;

namespace ParkingLot.DAL.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ParkingLotDbContext _db;
    public TicketRepository(ParkingLotDbContext db)
    {
        _db = db;
    }
    public Task <Ticket?> GetByIdAsync(int id) => _db.Tickets.Include(t=>t.Vehicle)
                .Include(t=>t.ParkingSlot)
                .FirstOrDefaultAsync(t => t.Id == id);
    public Task<Ticket?> GetByTicketNoAsync(string ticketNo) => _db.Tickets.Include(t=>t.Vehicle)
                .Include(t=>t.ParkingSlot)
                .FirstOrDefaultAsync(t => t.TicketNo == ticketNo);
    public Task<List<Ticket>> GetAllAsync() => _db.Tickets.Include(t => t.Vehicle)
              .Include(t => t.ParkingSlot)
              .AsNoTracking()
              .ToListAsync();

    public Task<Ticket?> GetActiveTicketForVehicleAsync(int vehicleId) => _db.Tickets.Include(t => t.ParkingSlot)
              .FirstOrDefaultAsync(t =>
                   t.VehicleId == vehicleId &&
                   t.Status == TicketStatus.Active);
    public Task<Ticket?> GetActiveTicketForSlotAsync(int slotId)
        => _db.Tickets.Include(t => t.Vehicle)
                .FirstOrDefaultAsync(t => t.ParkingSlotId == slotId && t.Status == TicketStatus.Active);

    public async Task AddAsync(Ticket ticket) => await _db.Tickets.AddAsync(ticket);
    public Task SaveChangesAsync() => _db.SaveChangesAsync();
}