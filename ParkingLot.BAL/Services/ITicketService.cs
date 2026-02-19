using ParkingLot.Domain.Entities;

namespace ParkingLot.BAL.Services;

public interface ITicketService
{
    Task<Ticket?> GetByIdAsync(int id);
    Task<Ticket?> GetByTicketNoAsync(string ticketNo);
    Task<List<Ticket>> GetAllAsync();

    // Phase 1: basic creation (will be enhanced with Check-In logic)
    Task<Ticket> CreateTicketAsync(Ticket ticket);

    // Phase 2: proper check-in / check-out methods
    // Task<Ticket> CheckInAsync(string plateNumber, VehicleType vehicleType, int slotId);
    // Task<Ticket> CheckOutAsync(string ticketNo);
}