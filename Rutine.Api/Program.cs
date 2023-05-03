using Microsoft.EntityFrameworkCore;
using Rutine.Domain.Interfaces;
using Rutine.Infraestructure.DataContext;
using Rutine.Infraestructure.UnitOfWork;
using Rutine.IService.Exercise;
using Rutine.IService.Rutine;
using Rutine.Service.ExerciseService;
using Rutine.Service.RutineService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Inyection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IRutineService, RutineService>();

// Add DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("RutineDB"));
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
