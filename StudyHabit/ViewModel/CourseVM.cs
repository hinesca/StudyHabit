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
               AddSessionCommand = new RelayCommand(AddSession, AddSessionCanExecute);
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

          private List<StudySession> _sessionList;
          public List<StudySession> SessionList 
          {
                get { return _sessionList; }
                set
                {
                    _sessionList = value;
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

          public bool isCourseSelected
          {
                get
                {
                    if (_selectedCourse == null) { return false; }
                    else return true;
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

          private bool _isUserAddingSession = false;

          public bool IsUserAddingSession
          {
                get { return _isUserAddingSession; }
                set
                {
                    _isUserAddingSession = value;
                    NotifyPropertyChanged();
                }
          }

          public string NewCourseName { get; set; }
          public string NewCourseCode { get; set; }
          public string NewCourseType { get; set; }
          public string NewCourseTerm { get; set; }
          public string NewCourseYear { get; set; }
          public string NewStartTime { get; set; }
          public string NewDuration { get; set; }
          public string NewCourseID { get; set; }


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

          public RelayCommand AddSessionCommand { get; private set; }

          public void AddSession(object o)
          {
                DataAccess.AddSession(NewStartTime, NewDuration, NewCourseID);
                UpdateData();
          }

          private bool AddSessionCanExecute(object o)
          {
                if (
                 string.IsNullOrWhiteSpace(NewStartTime) ||
                 string.IsNullOrWhiteSpace(NewDuration) ||
                 string.IsNullOrWhiteSpace(NewCourseID)
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

               DataTable sessionTable = DataAccess.GetStudySession();
               List<StudySession> sessionList = new List<StudySession>();

               foreach (DataRow row in sessionTable.Rows)
               {
                    sessionList.Add(new StudySession(
                        (int)row["Duration"],
                        (int)row["CouseID"]));
               }

               SessionList = sessionList;
          }
     }
}
