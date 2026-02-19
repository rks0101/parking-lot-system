using ParkingLot.Domain.Entities;
namespace ParkingLot.BAL.Services;

public interface IVehicleService
{
    Task<Vehicle?> GetByIdAsync(int id);
    Task<Vehicle?> GetByPlateAsync(string plateNumber);
    Task<List<Vehicle>> GetAllAsync(); 
    Task<Vehicle> RegisterVehicleAsync(Vehicle vehicle);
}