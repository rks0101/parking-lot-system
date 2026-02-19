using Microsoft.EntityFrameworkCore;
using ParkingLot.DAL.Data;
using ParkingLot.Domain.Entities;

namespace ParkingLot.DAL.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ParkingLotDbContext _db;

    public PaymentRepository(ParkingLotDbContext db)
    {
        _db = db;
    }

    public Task<Payment?> GetByIdAsync(int id)
        => _db.Payments
              .Include(p => p.Ticket)
              .ThenInclude(t => t.Vehicle)
              .FirstOrDefaultAsync(p => p.Id == id);

    public Task<Payment?> GetByTicketIdAsync(int ticketId)
        => _db.Payments
              .Include(p => p.Ticket)
              .ThenInclude(t => t.Vehicle)
              .FirstOrDefaultAsync(p => p.TicketId == ticketId);

    public Task<List<Payment>> GetAllAsync()
        => _db.Payments
              .Include(p => p.Ticket)
              .ThenInclude(t => t.Vehicle)
              .AsNoTracking()
              .ToListAsync();

    public async Task AddAsync(Payment payment)
        => await _db.Payments.AddAsync(payment);

    public Task SaveChangesAsync()
        => _db.SaveChangesAsync();
}