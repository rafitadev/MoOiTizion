namespace WindowsPerformanceOptimizer.App.Services.Recommendations;

public enum RecommendationCategory
{
    Startup,
    Power,
    Memory,
    Storage,
    Services,
    Visual,
    Gaming,
    Security
}

public sealed record RecommendationContext(
    int StartupAppCount,
    bool IsLaptop,
    bool IsOnBattery,
    int AvailableMemoryMb,
    int TotalMemoryMb,
    int DiskFreePercent,
    bool VisualEffectsAtBestAppearance,
    bool GameModeEnabled,
    bool RealTimeProtectionEnabled,
    int BackgroundServiceCount,
    string ActivePowerPlan)
{
    public static RecommendationContext Default => new(
        StartupAppCount: 19,
        IsLaptop: true,
        IsOnBattery: false,
        AvailableMemoryMb: 2600,
        TotalMemoryMb: 16384,
        DiskFreePercent: 11,
        VisualEffectsAtBestAppearance: true,
        GameModeEnabled: false,
        RealTimeProtectionEnabled: true,
        BackgroundServiceCount: 142,
        ActivePowerPlan: "Balanced");
}

public sealed record RecommendationCard(
    string Title,
    string Description,
    string ActionHint,
    RecommendationCategory Category,
    int Priority);
