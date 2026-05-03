namespace WindowsPerformanceOptimizer.App.Models;

public sealed class SystemSnapshot
{
    public double CpuUsage { get; init; }
    public double RamUsage { get; init; }
    public double DiskUsage { get; init; }
    public double GpuUsage { get; init; }
    public double Temperature { get; init; }
}
