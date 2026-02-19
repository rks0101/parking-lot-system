using System.ComponentModel.DataAnnotations;
using ParkingLot.Domain.Enums;
namespace ParkingLot.Domain.Entities;

public class Payment
{
    public int Id{get; set;}
    public int TicketId{get;set;}
    public Ticket? Ticket{get; set;}
    public decimal Amount{get; set;}
    public PaymentMethod Method{get; set;} = PaymentMethod.Card;
    public DateTime PaidAtUtc{get; set;} = DateTime.UtcNow;
    public string? ReferenceNo{get; set;}// UPI ref / card ref etc
}