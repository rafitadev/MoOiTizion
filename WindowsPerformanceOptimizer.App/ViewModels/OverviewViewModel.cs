using CommunityToolkit.Mvvm.ComponentModel;
using WindowsPerformanceOptimizer.App.Services;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class OverviewViewModel : ViewModelBase
{
    private readonly SystemMetricsService _metrics;
    [ObservableProperty] private double _cpu;
    [ObservableProperty] private double _ram;
    [ObservableProperty] private double _disk;
    [ObservableProperty] private double _gpu;
    [ObservableProperty] private double _temp;
    [ObservableProperty] private string _systemStatus = "Standard user mode";

    public OverviewViewModel(SystemMetricsService metrics, AuditLogService logService, AdminRightsService adminRights)
    {
        _metrics = metrics;
        SystemStatus = adminRights.IsAdministrator() ? "Administrator mode enabled" : "Standard user mode";
        Refresh();
        logService.Add("Overview initialized.");
    }

    public void Refresh()
    {
        var s = _metrics.GetSnapshot();
        Cpu = s.CpuUsage; Ram = s.RamUsage; Disk = s.DiskUsage; Gpu = s.GpuUsage; Temp = s.Temperature;
    }
}
