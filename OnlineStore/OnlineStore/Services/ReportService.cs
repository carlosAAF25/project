using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Services;

public class ReportService
{
    private readonly IOrderRepository _orderRepository;

    public ReportService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<string> GenerateAsync(IReportStrategy strategy)
    {
        var orders = await _orderRepository.GetAllAsync();
        return strategy.GenerateReport(orders);
    }
}
