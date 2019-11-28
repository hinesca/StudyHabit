using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
