using ParkingLot.Domain.Entities;
namespace ParkingLot.DAL.Repositories;

public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(int id);
    Task<Payment?> GetByTicketIdAsync(int ticketId);
    Task<List<Payment>> GetAllAsync();
    Task AddAsync(Payment payment);
    Task SaveChangesAsync();

}