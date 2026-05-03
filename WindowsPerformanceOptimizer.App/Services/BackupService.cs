namespace WindowsPerformanceOptimizer.App.Services;

public sealed class BackupService
{
    public string CreateBackupPoint(string reason)
    {
        // Placeholder for restore point export / registry snapshot strategy.
        return $"BK-{DateTime.UtcNow:yyyyMMddHHmmss}-{reason.Replace(' ', '_')}";
    }
}
