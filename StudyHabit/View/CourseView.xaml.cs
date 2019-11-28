using StudyHabit.ViewModel;
using System.Windows.Controls;


namespace StudyHabit.View
{
     /// <summary>
     /// Interaction logic for CourseView.xaml
     /// </summary>
     public partial class CourseView : UserControl
     {
          public CourseView()
          {
               InitializeComponent();
               DataContext = new CourseVM();
          }
     }
}
