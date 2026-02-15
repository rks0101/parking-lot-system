using Microsoft.EntityFrameworkCore;
using ParkingLot.Domain.Entities;

namespace ParkingLot.DAL.Data;

public class ParkingLotDbContext : DbContext
{
    public ParkingLotDbContext(DbContextOptions<ParkingLotDbContext> options)
        : base(options) { }

    public DbSet<ParkingSlot> ParkingSlots => Set<ParkingSlot>();
}