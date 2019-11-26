using StudyHabit.ViewModel;
using System.Windows.Controls;


namespace StudyHabit.View
{
     /// <summary>
     /// Interaction logic for LoginView.xaml
     /// </summary>
     public partial class LoginView : UserControl
     {
          public LoginView()
          {
               InitializeComponent();
               DataContext = new LoginVM(this);
          }
     }
}
