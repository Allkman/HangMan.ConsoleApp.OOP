using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HangMan.Data.Models
{
    public class PlayerScore
    {
        [Key]
        public int PlayerScoreId { get; set; }
        public int PlayerId { get; set; }
        public DateTime DatePlayed { get; set; }
        
        public int WordId { get; set; }
        public int GuessCount { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Word Word { get; set; }
        public virtual Player Player { get; set; }
    }
}
