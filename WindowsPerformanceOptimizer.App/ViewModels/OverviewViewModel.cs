using CommunityToolkit.Mvvm.ComponentModel;
using WindowsPerformanceOptimizer.App.Services;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class OverviewViewModel : ViewModelBase
{
    private readonly SystemMetricsService _metrics;
    private readonly AuditLogService _logService;

    [ObservableProperty] private double _cpu;
    [ObservableProperty] private double _ram;
    [ObservableProperty] private double _disk;
    [ObservableProperty] private double _gpu;
    [ObservableProperty] private double _temp;

    public OverviewViewModel(SystemMetricsService metrics, AuditLogService logService)
    {
        _metrics = metrics;
        _logService = logService;
        Refresh();
    }

    public void Refresh()
    {
        var s = _metrics.GetSnapshot();
        Cpu = s.CpuUsage; Ram = s.RamUsage; Disk = s.DiskUsage; Gpu = s.GpuUsage; Temp = s.Temperature;
        _logService.Add("Updated overview metrics.");
    }
}
