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
//Context
builder.Services.AddDbContext<MarketPlaceContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStrings:MarketPlace")));
//Services
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IReceiptService, ReceiptService>();
//Repositories(mb transient is better)
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
//Mapping
builder.Services.AddAutoMapper(c => c.AddProfile<AutoMapperConfig>());
//solution for problem with datetime(timestamp) type    
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
