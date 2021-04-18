using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.BL.Models
{
    public class HiddenWord
    {
        public HiddenWord(int wordSize)
        {
            CorrectGueses = new string[wordSize];
            IncorrectGueses = new List<string>();
        }

        public List<string> IncorrectGueses { get; set; }
        public string[] CorrectGueses { get; set; }

        public int HiddenLetterCount => CorrectGueses.Count(z => z == null);
        public int RevealdLetterCount => CorrectGueses.Count(z => z != null);

        public bool IsLetterGuessed(string letter)
        {
            return IncorrectGueses.Contains(letter);
        }
    }
}
