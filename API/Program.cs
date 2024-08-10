using Microsoft.EntityFrameworkCore;
using DatabaseR;
using Cards.Services;
using Users.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CardsApi>(
    options => options
    .UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
    new MySqlServerVersion(new Version(8, 0, 23)))
    );

builder.Services.AddScoped<ICardS, CardS>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<ICardsAnalisis, CardsAnalisis>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
