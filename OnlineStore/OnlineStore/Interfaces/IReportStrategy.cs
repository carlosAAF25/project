using OnlineStore.Models;

namespace OnlineStore.Interfaces;

public interface IReportStrategy
{
    string GenerateReport(IEnumerable<Order> orders);
}
