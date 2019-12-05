using System.Collections.Generic;

namespace StudyHabit.Model
{
     public class Course : ModelBase
     {
          public Course(long id, string name, string type, string code, string term, string year)
          {
               ID = id;
               Name = name;
               CourseType = type;
               Code = code;
               Term = term;
               Year = year;
          }

          public string CourseType { get; set; }
          public string Code { get; set; }
          public string Term { get; set; }
          public string Year { get; set; }
          public List<StudySession> StudySessions { get; set; } = new List<StudySession>();
          public List<string> StudyObjects { get; set; } = new List<string>();
     }
}
