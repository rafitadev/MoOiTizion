using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WindowsPerformanceOptimizer.App.Services;
using WindowsPerformanceOptimizer.App.Views;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly NavigationService _navigation;
    private readonly SystemMetricsService _metrics;
    private readonly AuditLogService _logs;

    [ObservableProperty] private UserControl? _currentView;
    [ObservableProperty] private bool _isDarkTheme;

    public MainViewModel(NavigationService navigation, SystemMetricsService metrics, ProfileService profileService, AuditLogService logService, TweakEngineService tweakEngineService, BackupService backupService, AdminRightsService adminRightsService)
    {
        _navigation = navigation;
        _metrics = metrics;
        _logs = logService;

        _navigation.OnNavigate += NavigateCore;
        ProfilesViewModel = new ProfilesViewModel(profileService, tweakEngineService, backupService, adminRightsService, _logs);
        MonitoringViewModel = new MonitoringViewModel(metrics);
        LogsViewModel = new LogsViewModel(_logs);
        CurrentView = new OverviewView { DataContext = new OverviewViewModel(metrics, _logs, adminRightsService) };
    }

    public ProfilesViewModel ProfilesViewModel { get; }
    public MonitoringViewModel MonitoringViewModel { get; }
    public LogsViewModel LogsViewModel { get; }

    partial void OnIsDarkThemeChanged(bool value) => ((App)System.Windows.Application.Current).SetTheme(value);

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
            _ => new OverviewView { DataContext = new OverviewViewModel(_metrics, _logs, new AdminRightsService()) }
        };
    }
}
