using WindowsPerformanceOptimizer.App.Services.Recommendations;

namespace WindowsPerformanceOptimizer.App.Services;

public sealed class RecommendationService
{
    private readonly IReadOnlyList<IRecommendationRule> _rules;

    public RecommendationService()
    {
        _rules = new IRecommendationRule[]
        {
            new StartupAppsRecommendationRule(),
            new PowerPlanRecommendationRule(),
            new MemoryPressureRecommendationRule(),
            new StorageHealthRecommendationRule(),
            new VisualEffectsRecommendationRule(),
            new BackgroundServicesRecommendationRule(),
            new GameModeRecommendationRule(),
            new SecurityBaselineRecommendationRule(),
        };
    }

    public IReadOnlyList<RecommendationCard> GetRecommendations(RecommendationContext? context = null)
    {
        var effectiveContext = context ?? RecommendationContext.Default;

        return _rules
            .Select(rule => rule.Evaluate(effectiveContext))
            .Where(card => card is not null)
            .Cast<RecommendationCard>()
            .OrderByDescending(card => card.Priority)
            .ThenBy(card => card.Title)
            .ToList();
    }

    public IReadOnlyList<string> GetRecommendationsLegacyText(RecommendationContext? context = null)
    {
        return GetRecommendations(context)
            .Select(c => $"[{c.Category}] {c.Title}: {c.Description}")
            .ToList();
    }
}
