using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.DL.Models
{
    public class LTName
    {
        public int LTNameId { get; set; }
        public int TopicId { get; set; }
        public string Text { get; set; }
        public virtual Topic Topic { get; set; }
        public int GuessCount { get; set; }
        public int CorrectGuessCount { get; set; }
        public virtual List<PlayerScore> PlayerScores { get; set; }
    }
}
