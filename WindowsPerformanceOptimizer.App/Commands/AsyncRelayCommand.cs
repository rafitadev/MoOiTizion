using System.Windows.Input;
namespace WindowsPerformanceOptimizer.App.Commands;
public sealed class AsyncRelayCommand(Func<Task> execute):ICommand{public event EventHandler? CanExecuteChanged; public bool CanExecute(object? p)=>true; public async void Execute(object? p)=>await execute();}
