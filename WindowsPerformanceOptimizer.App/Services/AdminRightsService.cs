using System.Security.Principal;

namespace WindowsPerformanceOptimizer.App.Services;

public sealed class AdminRightsService
{
    public bool IsAdministrator()
    {
        using var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
}
