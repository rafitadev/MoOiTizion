namespace WindowsPerformanceOptimizer.App.Services.Recommendations;

public interface IRecommendationRule
{
    RecommendationCard? Evaluate(RecommendationContext context);
}
