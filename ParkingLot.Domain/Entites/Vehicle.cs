using ParkingLot.Domain.Enums;
namespace ParkingLot.Domain.Entities;

public class Vehicle
{
    public int Id {get; set;}
    public string NumberPlate{get; set;} = string.Empty;
    public VehicleType? VehicleType{get; set;}
    public string? OwnerName { get; set; }
    public string? PhoneNumber { get; set;}

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

}