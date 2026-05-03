namespace WindowsPerformanceOptimizer.App.Tests;
public static class BackupTests { public static bool BackupId(){ var id=new Services.BackupService().CreateBackupPoint("x"); return !string.IsNullOrWhiteSpace(id);} }
