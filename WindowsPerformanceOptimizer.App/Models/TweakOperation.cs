namespace WindowsPerformanceOptimizer.App.Models;

public sealed class TweakOperation
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public bool MightAffectStability { get; init; }
    public bool RequiresAdministrator { get; init; }
}
