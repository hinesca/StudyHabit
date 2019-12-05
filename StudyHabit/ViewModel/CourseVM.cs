using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using StudyHabit.Model;

namespace StudyHabit.ViewModel
{
     public class CourseVM : ViewModelBase
     {
          public CourseVM()
          {
               AddCourseCommand = new RelayCommand(AddCourse, AddCourseCanExecute);
               UpdateData();
          }


          /********************************************************************
           * LoginVM Properties
           * *****************************************************************/

          private List<Course> _courseList;
          public List<Course> CourseList
          {
               get { return _courseList; }
               set
               {
                    _courseList = value;
                    NotifyPropertyChanged();
               }
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

          private List<string> _todoList;

          public List<string> ToDoList
          {
               get { return _todoList; }
               set
               {
                    _todoList = value;
                    NotifyPropertyChanged();
               }
          }


          private bool _isUserAddingCourse = false;

          public bool IsUserAddingCourse
          {
               get { return _isUserAddingCourse; }
               set
               {
                    _isUserAddingCourse = value;
                    NotifyPropertyChanged();
               }
          }


          public string NewCourseName { get; set; }
          public string NewCourseCode { get; set; }
          public string NewCourseType { get; set; }
          public string NewCourseTerm { get; set; }
          public string NewCourseYear { get; set; }



          /********************************************************************
           * CourseVM Commands and Command Properties
           * *****************************************************************/
          public RelayCommand AddCourseCommand { get; private set; }

          public void AddCourse(object o)
          {
               DataAccess.AddCourse(NewCourseName, NewCourseType, NewCourseCode, NewCourseTerm, NewCourseYear);
               UpdateData();
          }

          private bool AddCourseCanExecute(object o)
          {
               if (
                    string.IsNullOrWhiteSpace(NewCourseName) ||
                    string.IsNullOrWhiteSpace(NewCourseCode) ||
                    string.IsNullOrWhiteSpace(NewCourseType) ||
                    string.IsNullOrWhiteSpace(NewCourseTerm) ||
                    string.IsNullOrWhiteSpace(NewCourseYear)
                  )
                    return false;
               else return true;
          }

          /********************************************************************
           * CourseVM Methods
           * *****************************************************************/
          private void UpdateData()
          {
               DataTable courseTable = DataAccess.GetCourses();
               List<Course> courseList = new List<Course>();

               foreach (DataRow row in courseTable.Rows)
               {
                    courseList.Add(new Course(
                         (long)row["Id"],
                         (string)row["Name"],
                         (string)row["CourseType"],
                         (string)row["Code"],
                         (string)row["Term"],
                         (string)row["Year"]));
               }

               CourseList = courseList;
          }
     }
}
