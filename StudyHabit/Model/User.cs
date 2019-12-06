using System.Collections.Generic;


namespace StudyHabit.Model
{
     public class User
     {
          public string UserName { get; set; } = "";
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public string Password { get; set; }
          public string EMail { get; set; }
          public List<Course> CourseList { get; set; }
          public List<StudySession> SessionList { get; set; }
     }
}
