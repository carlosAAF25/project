using Microsoft.EntityFrameworkCore;
using OnlineStore;
using OnlineStore.Factories;
using OnlineStore.Interfaces;
using OnlineStore.Repositories;
using OnlineStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ReportService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dispatcher = new NotificationDispatcher();
dispatcher.Register(NotificationFactory.Create("email"));
dispatcher.Register(NotificationFactory.Create("sms"));
builder.Services.AddSingleton(dispatcher);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
