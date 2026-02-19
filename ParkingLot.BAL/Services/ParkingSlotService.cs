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

    public async Task<List<ParkingSlot>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<ParkingSlot?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

    public async Task<ParkingSlot?> GetBySlotNumberAsync(string slotNumber) => await _repo.GetBySlotNumberAsync(slotNumber);
    public async Task<ParkingSlot> CreateSlotAsync(ParkingSlot slot)
    {
        await _repo.AddAsync(slot);
        await _repo.SaveChangesAsync();
        return slot;
    }

    public async Task<bool> MarkSlotAsOccupiedAsync(int slotId)
    {
        var slot = await _repo.GetByIdAsync(slotId);
        if (slot == null) return false;
        slot.Status = SlotStatus.Occupied;
        await _repo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> MarkSlotAsAvailableAsync(int slotId)
    {
        var slot = await _repo.GetByIdAsync(slotId);
        if (slot == null) return false;
        slot.Status = SlotStatus.Available;
        await _repo.SaveChangesAsync();
        return true;
    }

}