using OnlineStore.Builders;
using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly NotificationDispatcher _notifier;

    public OrderService(IOrderRepository repository, NotificationDispatcher notifier)
    {
        _repository = repository;
        _notifier = notifier;
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
        _notifier.NotifyAll($"Nueva orden creada con total: {order.Total:C}");

        return order;
    }

    public Task<IEnumerable<Order>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Order?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
}
