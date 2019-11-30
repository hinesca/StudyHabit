using System.Collections.Generic;

namespace StudyHabit.Model
{
     public class Course
     {
          public string Name { get; set; }
          public int ID { get; set; }
          public string CourseType { get; set; }
          public List<string> StudySessions { get; set; }
          public List<string> StudyObjects { get; set; }
     }
}
