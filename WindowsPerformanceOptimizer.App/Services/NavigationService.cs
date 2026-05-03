using System;

namespace WindowsPerformanceOptimizer.App.Services;

public sealed class NavigationService
{
    public event Action<string>? OnNavigate;
    public void Navigate(string viewName) => OnNavigate?.Invoke(viewName);
}
