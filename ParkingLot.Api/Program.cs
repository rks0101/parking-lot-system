using Microsoft.EntityFrameworkCore;
using ParkingLot.BAL.Services;
using ParkingLot.DAL.Data;
using ParkingLot.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context (SQLite)
builder.Services.AddDbContext<ParkingLotDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// DAL
builder.Services.AddScoped<IParkingSlotRepository, ParkingSlotRepository>();

// BAL
builder.Services.AddScoped<IParkingSlotService, ParkingSlotService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
