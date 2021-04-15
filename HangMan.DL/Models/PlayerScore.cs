using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HangMan.DL.Models
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
        public virtual LTName LTName { get; set; }
        public virtual LTCity LTCity { get; set; }
        public virtual Country Country { get; set; }
        public virtual Furniture Furniture { get; set; }
        public virtual Player Player { get; set; }
    }
}
