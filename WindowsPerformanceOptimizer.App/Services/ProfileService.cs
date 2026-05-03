using WindowsPerformanceOptimizer.App.Models;

namespace WindowsPerformanceOptimizer.App.Services;

public sealed class ProfileService
{
    public IReadOnlyList<PerformanceProfile> GetDefaultProfiles() =>
    [
        new PerformanceProfile { Name = "Balanced", Description = "Mix between responsiveness and efficiency.", RequiresAdmin = false },
        new PerformanceProfile { Name = "Performance", Description = "Higher frequencies and aggressive scheduler behavior.", RequiresAdmin = true },
        new PerformanceProfile { Name = "Maximum Performance", Description = "Disables most power savings for lowest latency.", RequiresAdmin = true },
        new PerformanceProfile { Name = "Gaming", Description = "Optimizes priority and background service behavior.", RequiresAdmin = true },
        new PerformanceProfile { Name = "Custom", Description = "Tune each category manually.", RequiresAdmin = false }
    ];
}
