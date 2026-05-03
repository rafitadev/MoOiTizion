namespace WindowsPerformanceOptimizer.App.Services;

public sealed class AuditLogService
{
    private readonly List<string> _entries = [];

    public void Add(string message) => _entries.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {message}");
    public IReadOnlyList<string> GetAll() => _entries;
}
