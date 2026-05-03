namespace WindowsPerformanceOptimizer.App.Models;

public sealed class PerformanceProfile
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public bool RequiresAdmin { get; init; }
}
