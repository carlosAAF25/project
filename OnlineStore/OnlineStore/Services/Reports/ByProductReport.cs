using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Services.Reports;

public class ByProductReport : IReportStrategy
{
    public string GenerateReport(IEnumerable<Order> orders)
    {
        var items = orders.SelectMany(o => o.Items);
        var grouped = items.GroupBy(i => i.ProductName);
        var report = "📦 Reporte por producto:\n";
        foreach (var group in grouped)
        {
            var total = group.Sum(i => i.Subtotal);
            report += $"- {group.Key}: {total:C}\n";
        }
        return report;
    }
}
