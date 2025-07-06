using OnlineStore.Models;
using OnlineStore.Services;

namespace OnlineStore.Facades;

public class OrderFacade
{
    private readonly OrderService _orderService;
    private readonly NotificationDispatcher _notifier;

    public OrderFacade(OrderService orderService, NotificationDispatcher notifier)
    {
        _orderService = orderService;
        _notifier = notifier;
    }

    public async Task<Order> CreateOrderWithNotificationAsync(List<OrderItem> items)
    {
        var order = await _orderService.CreateOrderAsync(items);
        _notifier.NotifyAll($"✔️ Orden #{order.Id} creada. Total: {order.Total:C}");
        return order;
    }
}
