using ParkingLot.Domain.Entities;

namespace ParkingLot.DAL.Repositories;

public interface IParkingSlotRepository
{
    Task<List<ParkingSlot>> GetAllAsync();
    Task<ParkingSlot?> GetByIdAsync(int id);
    Task<ParkingSlot?> GetBySlotNumberAsync(string slotNumber);
    Task AddAsync(ParkingSlot slot);
    Task SaveChangesAsync();
}