using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WindowsPerformanceOptimizer.App.Models;
using WindowsPerformanceOptimizer.App.Services;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class ProfilesViewModel : ViewModelBase
{
    private readonly TweakEngineService _tweakEngine;
    private readonly BackupService _backupService;
    private readonly AdminRightsService _adminRights;
    private readonly AuditLogService _logs;

    public ObservableCollection<PerformanceProfile> Profiles { get; }
    public ObservableCollection<TweakOperation> Tweaks { get; }

    [ObservableProperty] private PerformanceProfile? _selectedProfile;
    [ObservableProperty] private string _status = "Select a profile and apply.";
    [ObservableProperty] private bool _requiresConfirmation;

    public ProfilesViewModel(ProfileService profileService, TweakEngineService tweakEngine, BackupService backupService, AdminRightsService adminRights, AuditLogService logs)
    {
        _tweakEngine = tweakEngine;
        _backupService = backupService;
        _adminRights = adminRights;
        _logs = logs;
        Profiles = new ObservableCollection<PerformanceProfile>(profileService.GetDefaultProfiles());
        Tweaks = new ObservableCollection<TweakOperation>(tweakEngine.GetSafeDefaultTweaks());
    }

    [RelayCommand]
    private void ApplySelected()
    {
        if (SelectedProfile is null) { Status = "Choose one profile first."; return; }
        if (SelectedProfile.RequiresAdmin && !_adminRights.IsAdministrator()) { Status = "Admin rights are required for this profile."; return; }

        var backupId = _backupService.CreateBackupPoint(SelectedProfile.Name);
        RequiresConfirmation = Tweaks.Any(t => t.MightAffectStability);
        Status = $"Profile {SelectedProfile.Name} queued. Backup: {backupId}.";
        _logs.Add($"Profile {SelectedProfile.Name} applied with backup {backupId}");
    }

    [RelayCommand]
    private void RestoreDefaults()
    {
        Status = "Default settings restored (safe simulation).";
        _logs.Add("Defaults restored.");
    }
}
