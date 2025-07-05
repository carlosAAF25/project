using OnlineStore.Builders;
using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order> CreateOrderAsync(List<OrderItem> items)
    {
        var builder = new OrderBuilder();

        foreach (var item in items)
        {
            builder.AddItem(item.ProductName, item.UnitPrice, item.Quantity);
        }

        var order = builder.SetStatus("Confirmed").Build();
        await _repository.AddAsync(order);

        return order;
    }

    public Task<IEnumerable<Order>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Order?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
}
