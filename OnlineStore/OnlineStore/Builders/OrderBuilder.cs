using OnlineStore.Models;

namespace OnlineStore.Builders;

public class OrderBuilder
{
    private readonly Order _order = new();

    public OrderBuilder AddItem(string productName, decimal unitPrice, int quantity)
    {
        _order.Items.Add(
            new OrderItem
            {
                ProductName = productName,
                UnitPrice = unitPrice,
                Quantity = quantity
            }
        );

        return this;
    }

    public OrderBuilder SetStatus(string status)
    {
        _order.Status = status;
        return this;
    }

    public Order Build()
    {
        _order.Total = _order.Items.Sum(i => i.Subtotal);
        _order.CreatedAt = DateTime.UtcNow;
        return _order;
    }
}
