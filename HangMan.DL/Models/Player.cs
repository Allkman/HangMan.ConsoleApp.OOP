using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HangMan.DL.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string PlayerName { get; set; }
        public virtual List<PlayerScore> PlayerScores { get; set; }
    }
}
