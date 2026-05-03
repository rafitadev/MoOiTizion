using WindowsPerformanceOptimizer.App.Models;

namespace WindowsPerformanceOptimizer.App.Services;

public sealed class SystemMetricsService
{
    private readonly Random _rng = new();

    public SystemSnapshot GetSnapshot() => new()
    {
        CpuUsage = _rng.Next(8, 98),
        RamUsage = _rng.Next(18, 94),
        DiskUsage = _rng.Next(5, 90),
        GpuUsage = _rng.Next(6, 98),
        Temperature = _rng.Next(35, 89)
    };
}
