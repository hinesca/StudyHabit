using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHabit.Model
{

    public class StudySession
    {
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int CourseID { get; set; }
    }
}
