using Members.Domain.Interfaces;
using Members.Infraestrucutre.Data;
using Members.Infraestrucutre.Repository;
using Members.IServicio.Members;
using Members.IServicio.User;
using Members.Service.MemberService;
using Members.Service.UserService;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IDBSettings>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<DBSettings>>().Value);

builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
