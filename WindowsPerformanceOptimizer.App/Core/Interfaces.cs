namespace WindowsPerformanceOptimizer.App.Core;

public interface IInitializable { void Initialize(); }
public interface IAsyncInitializable { Task InitializeAsync(CancellationToken ct = default); }
