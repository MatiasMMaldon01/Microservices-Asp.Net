using Microsoft.EntityFrameworkCore;
using Payment.Domain.Interfaces;
using Payment.Infraestructure.Data;
using Payment.Infraestructure.UnitOfWork;
using Payment.IService.Payment;
using Payment.IService.PriceList;
using Payment.Service.PaymentService;
using Payment.Service.PriceListService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Inyection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPriceListService, PriceListService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();


// Add DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("PaymentDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
