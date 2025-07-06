using Microsoft.AspNetCore.Mvc;
using OnlineStore.Facades;
using OnlineStore.Models;
using OnlineStore.Services;

namespace OnlineStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderFacade _facade;

    public OrderController(OrderFacade facade)
    {
        _facade = facade;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> Create(List<OrderItem> items)
    {
        var order = await _facade.CreateOrderWithNotificationAsync(items);
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpGet]
    public async Task<IEnumerable<Order>> Get([FromServices] OrderService service)
    {
        return await service.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetById(int id, [FromServices] OrderService service)
    {
        var order = await service.GetByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }
}
