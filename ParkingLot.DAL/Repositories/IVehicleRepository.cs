using ParkingLot.Domain.Entities;

namespace ParkingLot.DAL.Repositories;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByIdAsync(int id);
    Task<Vehicle?> GetByPlateAsync(string plateNumber);
    Task<List<Vehicle>> GetAllAsync();
    Task AddAsync(Vehicle vehicle);
    Task SaveChangesAsync();
}