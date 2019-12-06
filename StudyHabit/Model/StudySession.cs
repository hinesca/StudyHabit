using System;

namespace StudyHabit.Model
{

    public class StudySession
    {
        public StudySession(int duration, int cID)
        {
            Duration = duration;
            CourseID = cID;
            StartTime = DateTime.Now;
        }

        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int CourseID { get; set; }
    }
}
