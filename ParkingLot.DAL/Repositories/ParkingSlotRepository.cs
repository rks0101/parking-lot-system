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

    public async Task AddAsync(ParkingSlot slot)
        => await _db.ParkingSlots.AddAsync(slot);

    public Task SaveChangesAsync()
        => _db.SaveChangesAsync();
}