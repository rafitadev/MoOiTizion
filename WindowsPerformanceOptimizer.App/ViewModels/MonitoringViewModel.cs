using System.Collections.ObjectModel;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using WindowsPerformanceOptimizer.App.Services;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class MonitoringViewModel : ViewModelBase
{
    private readonly SystemMetricsService _metrics;
    private readonly DispatcherTimer _timer;

    public ObservableCollection<double> CpuSeries { get; } = [];
    public ObservableCollection<double> RamSeries { get; } = [];

    public MonitoringViewModel(SystemMetricsService metrics)
    {
        _metrics = metrics;
        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        _timer.Tick += (_, _) => Tick();
        _timer.Start();
    }

    private void Tick()
    {
        var snapshot = _metrics.GetSnapshot();
        Append(CpuSeries, snapshot.CpuUsage);
        Append(RamSeries, snapshot.RamUsage);
    }

    private static void Append(ObservableCollection<double> target, double value)
    {
        target.Add(value);
        if (target.Count > 60) target.RemoveAt(0);
    }
}
