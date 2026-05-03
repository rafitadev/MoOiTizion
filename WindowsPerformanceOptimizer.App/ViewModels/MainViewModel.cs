using System.Windows.Controls;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using WindowsPerformanceOptimizer.App.Services;
using WindowsPerformanceOptimizer.App.Views;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly NavigationService _navigation;

    [ObservableProperty] private UserControl? _currentView;

    public MainViewModel(NavigationService navigation, SystemMetricsService metrics, ProfileService profileService, AuditLogService logService)
    {
        _navigation = navigation;
        _navigation.OnNavigate += NavigateCore;
        _currentView = new OverviewView { DataContext = new OverviewViewModel(metrics, logService) };

        ProfilesViewModel = new ProfilesViewModel(profileService, logService);
        MonitoringViewModel = new MonitoringViewModel(metrics);
        LogsViewModel = new LogsViewModel(logService);
    }

    public ProfilesViewModel ProfilesViewModel { get; }
    public MonitoringViewModel MonitoringViewModel { get; }
    public LogsViewModel LogsViewModel { get; }

    [RelayCommand]
    private void Navigate(string target) => _navigation.Navigate(target);

    private void NavigateCore(string target)
    {
        CurrentView = target switch
        {
            "Monitoring" => new MonitoringView { DataContext = MonitoringViewModel },
            "Profiles" => new ProfilesView { DataContext = ProfilesViewModel },
            "Advanced" => new AdvancedView(),
            "Logs" => new LogsView { DataContext = LogsViewModel },
            "Help" => new HelpView(),
            _ => new OverviewView { DataContext = new OverviewViewModel(new SystemMetricsService(), new AuditLogService()) }
        };
    }
}
