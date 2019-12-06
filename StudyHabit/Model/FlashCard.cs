namespace StudyHabit.Model
{
     public class FlashCard
     {
          public FlashCard(string question, string answer, int deckId)
          {
                QuestionText = question;
                AnswerText = answer;
                FlashCardDeckID = deckId;
          }
          public string QuestionText { get; set; }
          public string AnswerText { get; set; }
          public int FlashCardDeckID { get; set; }
     }
}
