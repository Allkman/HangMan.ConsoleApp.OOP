using HangMan.BL.Models;
using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.BL.Managers.Interfaces
{
    public interface IHiddenWordManager
    {
        HiddenWord HiddenWord { get; set; }        
        int IncorrectGuesesCount { get; }
        bool HasHiddenLetters { get; }

        string GetHiddedWordStructure();
        void AddCorrectLetter(string guessedLetter, List<int> letterIndexes);
        void AddIncorrectLetter(string guessedLetter);
    }
}
