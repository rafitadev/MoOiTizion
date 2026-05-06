using System.Collections.ObjectModel;
using WindowsPerformanceOptimizer.App.Services;
using WindowsPerformanceOptimizer.App.Services.Recommendations;

namespace WindowsPerformanceOptimizer.App.ViewModels;

public partial class RecommendationsViewModel : ViewModelBase
{
    private readonly RecommendationService _recommendationService = new();

    public string Title => "Recommendations";

    public ObservableCollection<RecommendationCard> Items { get; } = [];

    public RecommendationsViewModel()
    {
        Refresh();
    }

    public void Refresh()
    {
        Items.Clear();
        foreach (var item in _recommendationService.GetRecommendations())
        {
            Items.Add(item);
        }
    }
}
