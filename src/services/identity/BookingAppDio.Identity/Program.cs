using BookingAppDio.Bus;
using BookingAppDio.Identity;
using BookingAppDio.Identity.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var env = builder.Environment;
// Add services to the container.

builder.Services.AddControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<IdentityDbContext>(options =>
                    options.UseNpgsql(
                          configuration.GetConnectionString("DefaultConnection"),
                         x => x.MigrationsAssembly(typeof(IdentityDbContext).Assembly.GetName().Name)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(IdentityRoot).Assembly);
//builder.Services.AddScoped<IDataSeeder, IdentityDataSeeder>();
builder.Services.AddCustomMassTransit(configuration, typeof(IdentityRoot).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.UseIdentityServer();

app.MapControllers();

app.Run();
