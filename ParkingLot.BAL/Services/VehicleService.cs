using ParkingLot.Domain.Entities;
using ParkingLot.DAL.Repositories;
using ParkingLot.Domain.Enums;
namespace ParkingLot.BAL.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repo;

    public VehicleService(IVehicleRepository repo)
    {
        _repo = repo;
    }

    public async Task<Vehicle?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task<Vehicle?> GetByPlateAsync(string plateNumber) => await _repo.GetByPlateAsync(plateNumber);
    public async Task<List<Vehicle>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Vehicle> RegisterVehicleAsync(Vehicle vehicle)
    {
        await _repo.AddAsync(vehicle);
        await _repo.SaveChangesAsync();
        return vehicle;
    }
}