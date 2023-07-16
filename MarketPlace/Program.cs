using MarketPlace.Repositories.Interfaces;
using MarketPlace.Repositories;
using MarketPlace.Services;
using MarketPlace.Services.Interfaces;
using MarketPlace.Contexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MarketPlace.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MarketPlaceContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStrings:MarketPlace")));
builder.Services.AddScoped<IUserService, UserService>();
//mb transient better
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(c => c.AddProfile<AutoMapperConfig>());

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
