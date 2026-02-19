using Microsoft.EntityFrameworkCore;
using ParkingLot.DAL.Data;
using ParkingLot.Domain.Entities;
using SQLitePCL;

namespace ParkingLot.DAL.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly ParkingLotDbContext _db;
    public VehicleRepository(ParkingLotDbContext db)
    {
        _db = db;
    }

    public Task<Vehicle?> GetByIdAsync(int id) => _db.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
    public Task<Vehicle?> GetByPlate(string plateNumber) => _db.Vehicles.FirstOrDefaultAsync(v => v.NumberPlate == plateNumber);
    public Task<List<Vehicle>> GetAllAsync() => _db.Vehicles.AsNoTracking().ToListAsync();
    public async Task AddAsync(Vehicle vehicle) => await _db.Vehicles.AddAsync(vehicle);
    public Task SaveChangesAsync() => _db.SaveChangesAsync();
}