using ParkingLot.Domain.Enums;

namespace ParkingLot.Domain.Entities;
public class ParkingSLot
{
    public int Id{get; set;}
    public string SlotNumber{get; set;} = string.Empty;//Initially it should be empty
    public VehicleType VehicleType {get; set;}
    public SlotStatus Status{get; set;} = SlotStatus.Available;//Initialy all the slots should be available
}