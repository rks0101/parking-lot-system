using ParkingLot.Domain.Entities;

namespace ParkingLot.BAL.Services;

public interface IParkingSlotService
{
    // Task<ParkingSlot> GetParkingSlotByIdAsync(int id);
    // Task<IEnumerable<ParkingSlot>> GetAllParkingSlotsAsync();
    // Task AddParkingSlotAsync(ParkingSlot parkingSlot);
    // Task UpdateParkingSlotAsync(ParkingSlot parkingSlot);
    // Task DeleteParkingSlotAsync(int id);
    Task<List<ParkingSlot>> GetAllAsync();
    Task<ParkingSlot?> GetByIdAsync(int id);
    Task<ParkingSlot?> GetBySlotNumberAsync(string slotNumber);

    Task<ParkingSlot> CreateSlotAsync(ParkingSlot slot);
    Task<bool> MarkSlotAsOccupiedAsync(int slotId);
    Task<bool> MarkSlotAsAvailableAsync(int slotId);

}