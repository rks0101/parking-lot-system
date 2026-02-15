using ParkingLot.Domain.Entities;

namespace ParkingLot.BAL.Services;

public interface IParkingSlotService
{
    Task<List<ParkingSlot>> GetSlotsAsync();
    Task<ParkingSlot> CreateSlotAsync(ParkingSlot slot);
}