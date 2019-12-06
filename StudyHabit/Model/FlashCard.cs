namespace StudyHabit.Model
{
     public class FlashCard
     {
          public FlashCard(string question, string answer, int courseID)
          {
                QuestionText = question;
                AnswerText = answer;
                CourseID = courseID;
          }
          public string QuestionText { get; set; }
          public string AnswerText { get; set; }
          public int CourseID { get; set; }
     }
}
