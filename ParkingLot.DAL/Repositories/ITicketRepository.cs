using ParkingLot.Domain.Entities;
namespace ParkingLot.DAL.Repositories;

public interface ITicketRepository
{
    Task <Ticket?> GetByIdAsync(int id);
    Task<Ticket?> GetByTicketNoAsync(string ticketNo);
    Task<List<Ticket>> GetAllAsync();
    // Active ticket for a given vehicle (to prevent double check-in)
    Task<Ticket?> GetActiveTicketForVehicleAsync(int vehicleId);

    // Active ticket for a given slot (for checkout/validation)
    Task<Ticket?> GetActiveTicketForSlotAsync(int slotId);

    Task AddAsync(Ticket ticket);
    Task SaveChangesAsync();

}