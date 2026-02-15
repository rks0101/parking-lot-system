using ParkingLot.Domain.Enums;

namespace ParkingLot.Domain.Entities;

public class ParkingSlot
{
    public int Id { get; set; }
    public string SlotNumber { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public SlotStatus Status { get; set; } = SlotStatus.Available;
}