using System;
using System.Windows.Input;

/// <summary>
/// This class implements the ICommand interface and is used for passing
/// commands from a View to its respective view model.
/// </summary>
namespace StudyHabit
{
     public class RelayCommand : ICommand
     {
          public RelayCommand(Action<object> execute, Predicate<object> canExecute)
          {
               if (execute == null)
                    throw new NullReferenceException("execute");

               _execute = execute;
               _canExecute = canExecute;
          }

          public RelayCommand(Action<object> execute) : this(execute, null) { }
          readonly Action<object> _execute;
          readonly Predicate<object> _canExecute;

          public event EventHandler CanExecuteChanged
          {
               add { CommandManager.RequerySuggested += value; }
               remove { CommandManager.RequerySuggested -= value; }
          }

          public bool CanExecute(object param)
          {
               return _canExecute == null ? true : _canExecute(param);
          }

          public void Execute(object param)
          {
               _execute.Invoke(param);
          }
     }
}
