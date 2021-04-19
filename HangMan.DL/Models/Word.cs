using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.DL.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public Topic Topic { get; set; }
        public int TopicId { get; set; }
        public LTName LTName { get; set; }
        public LTCity LTCity { get; set; }
        public Country Country { get; set; }
        public Furniture Furniture { get; set; }

    }
}
