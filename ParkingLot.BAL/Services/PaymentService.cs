using ParkingLot.DAL.Repositories;
using ParkingLot.Domain.Entities;

namespace ParkingLot.BAL.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repo;

    public PaymentService(IPaymentRepository repo)
    {
        _repo = repo;
    }

    public Task<Payment?> GetByIdAsync(int id)
        => _repo.GetByIdAsync(id);

    public Task<Payment?> GetByTicketIdAsync(int ticketId)
        => _repo.GetByTicketIdAsync(ticketId);

    public Task<List<Payment>> GetAllAsync()
        => _repo.GetAllAsync();

    public async Task<Payment> CreatePaymentAsync(Payment payment)
    {
        if (payment.Amount <= 0)
            throw new ArgumentException("Payment amount must be greater than zero.", nameof(payment.Amount));

        await _repo.AddAsync(payment);
        await _repo.SaveChangesAsync();
        return payment;
    }
}