# Windows Performance Optimizer (Original Project)

Aplicativo desktop Windows em **C# + WPF (.NET 8)** com arquitetura **MVVM** para otimização e monitoramento de desempenho.

## O que já está implementado

- Estrutura inicial de solução e projeto WPF.
- Navegação por sidebar com páginas principais:
  - Overview
  - Monitoring
  - Performance Profiles
  - Advanced
  - Logs & History
  - Help
- Base de monitoramento em tempo real (simulação de métricas CPU/RAM etc.).
- Perfis iniciais:
  - Balanced
  - Performance
  - Maximum Performance
  - Gaming
  - Custom
- Base de aplicação/restauração de perfil (simulada) com logs.
- Serviço de log de ações.

## Estrutura

- `WindowsPerformanceOptimizer.App/Models` → modelos de domínio.
- `WindowsPerformanceOptimizer.App/Services` → serviços de sistema, perfis, logs e navegação.
- `WindowsPerformanceOptimizer.App/ViewModels` → lógica MVVM.
- `WindowsPerformanceOptimizer.App/Views` → telas XAML.

## Como compilar

1. Instale o **.NET 8 SDK** e workloads de desktop Windows.
2. Abra a solução `WindowsPerformanceOptimizer.sln` no Visual Studio 2022+.
3. Restaure pacotes NuGet.
4. Build em `Debug|Any CPU`.

## Próximos passos sugeridos

- Trocar métricas simuladas por coleta real (PerformanceCounter, WMI, ETW etc.).
- Implementar detecção de admin rights e elevação segura.
- Criar módulo de backup/restore real para tweaks.
- Aplicar tweaks reais com confirmação dupla e rollback.
- Adicionar tema Light/Dark com `ResourceDictionary` dinâmico.
- Integrar gráficos modernos (LiveCharts) nas páginas de monitoramento.

## Exemplos de tweaks (planejados)

- Plano de energia: alternar para perfil de energia selecionado.
- Inicialização: desabilitar entradas não essenciais (com confirmação).
- Serviços: otimização segura de serviços não críticos.
- Prioridade de processos: elevar prioridade para apps definidos no perfil Gaming.
- Limpeza opcional de RAM: rotina controlada e não agressiva.
