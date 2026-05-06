namespace WindowsPerformanceOptimizer.App.Services.Recommendations;

public sealed class StartupAppsRecommendationRule : IRecommendationRule
{
    public RecommendationCard? Evaluate(RecommendationContext context)
    {
        if (context.StartupAppCount <= 12) return null;
        return new RecommendationCard(
            "Reduza aplicativos de inicialização",
            $"Foram detectados {context.StartupAppCount} apps iniciando com o Windows, o que aumenta tempo de boot.",
            "Desative apps de alto impacto em Startup.",
            RecommendationCategory.Startup,
            95);
    }
}

public sealed class PowerPlanRecommendationRule : IRecommendationRule
{
    public RecommendationCard? Evaluate(RecommendationContext context)
    {
        if (context.ActivePowerPlan.Equals("High performance", StringComparison.OrdinalIgnoreCase)) return null;
        if (context.IsLaptop && context.IsOnBattery) return null;

        return new RecommendationCard(
            "Ative plano High Performance",
            "Plano Balanced prioriza eficiência energética e pode limitar boost em tarefas pesadas.",
            "Troque para High Performance quando conectado na tomada.",
            RecommendationCategory.Power,
            90);
    }
}

public sealed class MemoryPressureRecommendationRule : IRecommendationRule
{
    public RecommendationCard? Evaluate(RecommendationContext context)
    {
        var availableRatio = context.TotalMemoryMb == 0 ? 1 : (double)context.AvailableMemoryMb / context.TotalMemoryMb;
        if (availableRatio >= 0.20) return null;

        return new RecommendationCard(
            "Pressão de memória detectada",
            $"Memória livre em {availableRatio:P0}. Feche apps residentes e ajuste paginação.",
            "Aplicar preset de limpeza de RAM e hibernação seletiva.",
            RecommendationCategory.Memory,
            98);
    }
}

public sealed class StorageHealthRecommendationRule : IRecommendationRule
{
    public RecommendationCard? Evaluate(RecommendationContext context)
    {
        if (context.DiskFreePercent >= 15) return null;

        return new RecommendationCard(
            "Espaço em disco baixo",
            $"Unidade de sistema com apenas {context.DiskFreePercent}% livre. Isso reduz desempenho em updates e cache.",
            "Executar limpeza de arquivos temporários e Storage Sense.",
            RecommendationCategory.Storage,
            94);
    }
}

public sealed class VisualEffectsRecommendationRule : IRecommendationRule
{
    public RecommendationCard? Evaluate(RecommendationContext context)
    {
        if (!context.VisualEffectsAtBestAppearance) return null;

        return new RecommendationCard(
            "Otimize efeitos visuais",
            "Configuração atual prioriza aparência e pode aumentar latência de renderização.",
            "Aplicar modo 'Best performance' para animações e sombras.",
            RecommendationCategory.Visual,
            72);
    }
}

public sealed class BackgroundServicesRecommendationRule : IRecommendationRule
{
    public RecommendationCard? Evaluate(RecommendationContext context)
    {
        if (context.BackgroundServiceCount <= 130) return null;

        return new RecommendationCard(
            "Muitos serviços em segundo plano",
            $"{context.BackgroundServiceCount} serviços ativos podem afetar CPU idle e tempo de resposta.",
            "Revisar serviços não essenciais com rollback seguro.",
            RecommendationCategory.Services,
            86);
    }
}

public sealed class GameModeRecommendationRule : IRecommendationRule
{
    public RecommendationCard? Evaluate(RecommendationContext context)
    {
        if (context.GameModeEnabled) return null;

        return new RecommendationCard(
            "Habilite Game Mode",
            "Game Mode ajuda a priorizar processo do jogo e reduzir tarefas em background durante gameplay.",
            "Ativar Game Mode no Windows e neste app.",
            RecommendationCategory.Gaming,
            60);
    }
}

public sealed class SecurityBaselineRecommendationRule : IRecommendationRule
{
    public RecommendationCard? Evaluate(RecommendationContext context)
    {
        if (context.RealTimeProtectionEnabled) return null;

        return new RecommendationCard(
            "Restaure baseline de segurança",
            "Proteção em tempo real está desativada. Isso é risco alto e pode degradar performance por malware.",
            "Reativar Microsoft Defender e executar verificação rápida.",
            RecommendationCategory.Security,
            100);
    }
}
