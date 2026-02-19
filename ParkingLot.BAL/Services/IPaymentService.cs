using ParkingLot.Domain.Entities;

namespace ParkingLot.BAL.Services;

public interface IPaymentService
{
    Task<Payment?> GetByIdAsync(int id);
    Task<Payment?> GetByTicketIdAsync(int ticketId);
    Task<List<Payment>> GetAllAsync();

    Task<Payment> CreatePaymentAsync(Payment payment);
}