using System.Windows;

namespace WindowsPerformanceOptimizer.App;

public partial class App : Application
{
    public void SetTheme(bool dark)
    {
        var themePath = dark ? "Themes/DarkTheme.xaml" : "Themes/LightTheme.xaml";
        Resources.MergedDictionaries[0] = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };
    }
}
