using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceManager.IManager;
using ServiceManager.Manager;
using UserMicroservices.Service;

var builder = WebApplication.CreateBuilder(args);

#region Add Services
builder.Services.ConfigureCors();

builder.Services.AddControllers();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICartRepository, CartRepository>();

builder.Services.AddScoped<IOrder, Order>();

builder.Services.AddScoped<ICart, Cart>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();