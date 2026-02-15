using ParkingLot.DAL.Repositories;
using ParkingLot.Domain.Entities;
using ParkingLot.Domain.Enums;

namespace ParkingLot.BAL.Services;

public class ParkingSlotService : IParkingSlotService
{
    private readonly IParkingSlotRepository _repo;

    public ParkingSlotService(IParkingSlotRepository repo)
    {
        _repo = repo;
    }

    public Task<List<ParkingSlot>> GetSlotsAsync()
        => _repo.GetAllAsync();

    public async Task<ParkingSlot> CreateSlotAsync(ParkingSlot slot)
    {
        if (string.IsNullOrWhiteSpace(slot.SlotNumber))
            throw new ArgumentException("SlotNumber is required.");

        // default
        slot.Status = SlotStatus.Available;

        await _repo.AddAsync(slot);
        await _repo.SaveChangesAsync();
        return slot;
    }
}