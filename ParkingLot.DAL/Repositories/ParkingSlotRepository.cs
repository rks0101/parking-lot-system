using Microsoft.EntityFrameworkCore;
using ParkingLot.DAL.Data;
using ParkingLot.Domain.Entities;

namespace ParkingLot.DAL.Repositories;

public class ParkingSlotRepository : IParkingSlotRepository
{
    private readonly ParkingLotDbContext _db;

    public ParkingSlotRepository(ParkingLotDbContext db)
    {
        _db = db;
    }

    public Task<List<ParkingSlot>> GetAllAsync()
        => _db.ParkingSlots.AsNoTracking().ToListAsync();
    
    public Task<ParkingSlot?> GetByIdAsync(int id)
        => _db.ParkingSlots.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
    
    public Task<ParkingSlot?> GetBySlotNumberAsync(string slotNumber)
        => _db.ParkingSlots.AsNoTracking().FirstOrDefaultAsync(s => s.SlotNumber == slotNumber);

    public async Task AddAsync(ParkingSlot slot)
        => await _db.ParkingSlots.AddAsync(slot);

    public Task SaveChangesAsync()
        => _db.SaveChangesAsync();
}