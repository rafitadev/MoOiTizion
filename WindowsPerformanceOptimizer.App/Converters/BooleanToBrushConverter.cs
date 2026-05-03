using System.Globalization;using System.Windows.Data;using System.Windows.Media;
namespace WindowsPerformanceOptimizer.App.Converters;
public sealed class BooleanToBrushConverter : IValueConverter { public object Convert(object value, Type t, object p, CultureInfo c)=> (value is true)?Brushes.LimeGreen:Brushes.OrangeRed; public object ConvertBack(object value, Type t, object p, CultureInfo c)=>Binding.DoNothing; }
