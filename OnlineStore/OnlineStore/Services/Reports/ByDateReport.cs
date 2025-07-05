using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Services.Reports;

public class ByDateReport : IReportStrategy
{
    public string GenerateReport(IEnumerable<Order> orders)
    {
        var grouped = orders.GroupBy(o => o.CreatedAt.Date);
        var report = "📅 Reporte por fecha:\n";
        foreach (var group in grouped)
        {
            var total = group.Sum(o => o.Total);
            report += $"- {group.Key.ToShortDateString()}: {total:C}\n";
        }
        return report;
    }
}
