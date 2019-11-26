using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// The View Model base class. All view models inherit from this class
/// </summary>
namespace StudyHabit.ViewModel
{
     public class ViewModelBase : INotifyPropertyChanged
     {
          public event PropertyChangedEventHandler PropertyChanged;

          protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
          {
               if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
     }
}
