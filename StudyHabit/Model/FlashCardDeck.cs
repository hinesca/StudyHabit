using System;
using System.Collections.Generic;

namespace StudyHabit.Model
{
    public class FlashCardDeck : ModelBase
    {
        public List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
        public int CourseId { get; set; }
    }
}
