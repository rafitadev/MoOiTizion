# PulseTune Optimizer (Windows Performance Optimizer)

Projeto **original** de desktop app para Windows em **C#/.NET 8 + WPF**, focado em otimização, monitoramento e tuning com arquitetura modular e escalável.

## Visão geral
- Interface moderna com sidebar, top actions e páginas dedicadas.
- Suporte base para tema claro/escuro.
- Dashboard com status de sistema e módulos de ação rápida.
- Monitoramento contínuo (CPU, RAM, Disco, GPU, Rede, Temperatura) com base extensível.
- Perfis de desempenho: Balanced, Performance, Maximum Performance, Gaming, Custom (+ Benchmark/Economy na base).
- Backup/restore antes de ações críticas (pipeline base).
- Logs e histórico de alterações.
- Detecção de hardware e recomendações (placeholders funcionais).

## Arquitetura (pastas principais)
- `App/`, `Views/`, `ViewModels/`, `Models/`, `Services/`
- `Helpers/`, `Controls/`, `Resources/`, `Themes/`, `Converters/`, `Commands/`
- `Data/`, `Core/`, `Diagnostics/`, `Settings/`, `Logging/`
- `BackupRestore/`, `PerformanceProfiles/`, `SystemTweaks/`, `Monitoring/`, `Startup/`, `Controllers/`, `Tests/`

## Módulos implementados na base
- Navegação e shell principal (`MainWindow`, `MainViewModel`, `NavigationService`).
- Páginas: Dashboard, Monitoring, Profiles, Tweaks, Startup, Backup, Settings, Logs, About, Help, Advanced, Recommendations, Custom Profile.
- Componentes reutilizáveis: cards, status badge, gráficos placeholder, ações rápidas, toast, diálogo de confirmação.
- Serviços de domínio: power plans, processo/prioridade, tuning de serviços, backup, benchmark/gaming mode, recomendações, update checker placeholder.
- Modelos ricos para logs, backup, hardware, tweaks, recomendações e histórico.

## Compilar
1. Instale Visual Studio 2022 (17.8+) com workload de Desktop .NET ou .NET 8 SDK no Windows.
2. Abra `WindowsPerformanceOptimizer.sln`.
3. Restaure pacotes.
4. Compile em `Debug`.

## Qualidade e segurança
- Sem reutilização de código/layout/texto/ícones proprietários.
- Fluxo “backup-first” para ajustes potencialmente sensíveis.
- Mensagens claras de limitação e necessidade de permissões administrativas.
- Estrutura pensada para crescimento (camadas bem separadas).

## Próximos passos recomendados
- Integrar telemetria real com APIs nativas do Windows (WMI/PDH/ETW).
- Implementar gráficos completos e persistência de histórico em disco.
- Adicionar testes unitários com framework dedicado (xUnit/NUnit).
- Criar pipeline de validação e assinatura de release.
