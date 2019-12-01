using System.Collections.Generic;

namespace StudyHabit.Model
{
     public class Course
     {
          public string Name { get; set; }
          public int ID { get; set; }
          public string Prefix { get; set; }
          public int Code { get; set; }
          public string Season { get; set; }
          public int Year { get; set; }
          public List<StudySession> StudySessions { get; set; }
          public List<string> StudyObjects { get; set; }
     }
}
