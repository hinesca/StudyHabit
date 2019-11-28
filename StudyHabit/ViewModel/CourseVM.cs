using System.Collections.ObjectModel;
using StudyHabit.Model;

namespace StudyHabit.ViewModel
{
     public class CourseVM : ViewModelBase
     {
          private ObservableCollection<Course> _courseList;
          public ObservableCollection<Course> CourseList
          {
               get { return _courseList; }
               set { _courseList = value; }
          }

          private Course _selectedCourse;

          public Course SelectedCourse
          {
               get { return _selectedCourse; }
               set
               {
                    _selectedCourse = value;
                    NotifyPropertyChanged();
               }
          }

          private string _selectedCourseName;

          public string SelectedCourseName
          {
               get { return _selectedCourseName; }
               set
               {
                    _selectedCourseName = value;
                    NotifyPropertyChanged();
               }
          }

          private ObservableCollection<string> _todoList;

          public ObservableCollection<string> ToDoList
          {
               get { return _todoList; }
               set
               {
                    _todoList = value;
                    NotifyPropertyChanged();
               }
          }





     }
}
