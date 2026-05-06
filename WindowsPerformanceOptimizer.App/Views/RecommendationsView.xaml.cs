using System.Windows.Controls;
using WindowsPerformanceOptimizer.App.ViewModels;

namespace WindowsPerformanceOptimizer.App.Views;

public partial class RecommendationsView : UserControl
{
    public RecommendationsView()
    {
        InitializeComponent();
        DataContext = new RecommendationsViewModel();
    }
}
