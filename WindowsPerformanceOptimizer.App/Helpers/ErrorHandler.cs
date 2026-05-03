namespace WindowsPerformanceOptimizer.App.Helpers;

public static class ErrorHandler { public static string ToUserMessage(Exception ex)=>$"Unexpected error: {ex.Message}"; }
