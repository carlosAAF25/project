using Microsoft.AspNetCore.Mvc;
using OnlineStore.Interfaces;
using OnlineStore.Services;
using OnlineStore.Services.Reports;

namespace OnlineStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly ReportService _reportService;

    public ReportController(ReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("by-date")]
    public async Task<string> GetByDate()
    {
        var strategy = new ByDateReport();
        return await _reportService.GenerateAsync(strategy);
    }

    [HttpGet("by-product")]
    public async Task<string> GetByProduct()
    {
        var strategy = new ByProductReport();
        return await _reportService.GenerateAsync(strategy);
    }
}
