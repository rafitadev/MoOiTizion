using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using WindowsPerformanceOptimizer.App.Services;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class LogsViewModel : ViewModelBase
{
    private readonly AuditLogService _logService;
    public ObservableCollection<string> Entries { get; } = [];

    public LogsViewModel(AuditLogService logService)
    {
        _logService = logService;
        Refresh();
    }

    [RelayCommand]
    private void Refresh()
    {
        Entries.Clear();
        foreach (var entry in _logService.GetAll()) Entries.Add(entry);
    }
}
