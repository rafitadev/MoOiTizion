using System.Globalization;using System.Windows.Data;
namespace WindowsPerformanceOptimizer.App.Converters;
public sealed class EnumToDescriptionConverter : IValueConverter { public object Convert(object value, Type t, object p, CultureInfo c)=>value?.ToString()??string.Empty; public object ConvertBack(object value, Type t, object p, CultureInfo c)=>Binding.DoNothing; }
