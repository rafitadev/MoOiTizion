using System.Windows;
using WindowsPerformanceOptimizer.App.Services;
using WindowsPerformanceOptimizer.App.ViewModels;

namespace WindowsPerformanceOptimizer.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel(new NavigationService(), new SystemMetricsService(), new ProfileService(), new AuditLogService());
    }
}
