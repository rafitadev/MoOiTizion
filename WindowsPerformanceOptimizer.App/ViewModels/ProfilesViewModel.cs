using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WindowsPerformanceOptimizer.App.Models;
using WindowsPerformanceOptimizer.App.Services;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class ProfilesViewModel : ViewModelBase
{
    private readonly AuditLogService _logs;

    public ObservableCollection<PerformanceProfile> Profiles { get; }

    [ObservableProperty] private PerformanceProfile? _selectedProfile;
    [ObservableProperty] private string _status = "Choose a profile and apply safely.";

    public ProfilesViewModel(ProfileService profileService, AuditLogService logs)
    {
        _logs = logs;
        Profiles = new ObservableCollection<PerformanceProfile>(profileService.GetDefaultProfiles());
    }

    [RelayCommand]
    private void ApplySelected()
    {
        if (SelectedProfile is null)
        {
            Status = "Select a profile first.";
            return;
        }

        Status = $"Applied {SelectedProfile.Name} profile (simulation). Backup created.";
        _logs.Add($"Applied profile: {SelectedProfile.Name}");
    }

    [RelayCommand]
    private void RestoreDefaults()
    {
        Status = "Restored baseline defaults (simulation).";
        _logs.Add("Restored default configuration.");
    }
}
