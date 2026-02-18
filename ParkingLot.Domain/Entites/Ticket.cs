using ParkingLot.Domain.Enums;
namespace ParkingLot.Domain.Entities;

public class Ticket
{
    public int Id{get; set;}
    public string TicketNo{get; set;} =  Guid.NewGuid().ToString("N");
    public int VehicleId{get; set;}
    public Vehicle? Vehicle{get; set;}
    public int ParkingSlotId{get; set;}
    public ParkingSlot? ParkingSlot{get; set;}
    public DateTime ChekInTimeUtc{get; set;} = DateTime.UtcNow;
    public DateTime? CheckOutTime{get; set;}
    public TicketStatus Status{get; set;} = TicketStatus.Active;
    public decimal? CalculatedAmount{get; set;}//setting at checkout
    //1:1 optional payment
    public Payment? Payment { get; set; }

}