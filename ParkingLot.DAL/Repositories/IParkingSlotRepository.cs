using ParkingLot.Domain.Entities;

namespace ParkingLot.DAL.Repositories;

public interface IParkingSlotRepository
{
    Task<List<ParkingSlot>> GetAllAsync();
    Task AddAsync(ParkingSlot slot);
    Task SaveChangesAsync();
}