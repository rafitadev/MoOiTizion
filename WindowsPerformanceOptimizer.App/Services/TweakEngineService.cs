using WindowsPerformanceOptimizer.App.Models;

namespace WindowsPerformanceOptimizer.App.Services;

public sealed class TweakEngineService
{
    public IReadOnlyList<TweakOperation> GetSafeDefaultTweaks() =>
    [
        new TweakOperation { Name = "Power plan optimization", Description = "Switches power behavior according to selected profile.", RequiresAdministrator = true, MightAffectStability = false },
        new TweakOperation { Name = "Background services tuning", Description = "Disables non-essential background services safely.", RequiresAdministrator = true, MightAffectStability = true },
        new TweakOperation { Name = "Startup optimization", Description = "Reduces boot overhead by delaying optional startup entries.", RequiresAdministrator = true, MightAffectStability = false }
    ];
}
