using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.BL.Managers.Interfaces
{
    public interface IGuess
    {
        bool IsWordGuessed { get; }
        void CheckLetter();
        void CheckSelectedWordIsCorrect(int topicNumber);
        void CheckLetterOfSelectedWord(int topicNUmber);
    }
}
