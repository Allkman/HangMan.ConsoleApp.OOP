using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HangMan.Data.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Word> Words { get; set; }
        public virtual List<PlayerScore> PlayerScores { get; set; }
    }
}
