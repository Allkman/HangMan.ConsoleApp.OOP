using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.BL.Managers.Interfaces
{
    public interface IGuess
    {
        bool IsWordGuessed { get; }        
        void CheckSelectedWordIsCorrect(int topicNumber);
        void CheckLetterOfSelectedWord(int topicNUmber);
        bool CheckLTNameCorrect();
        bool CheckLTCityCorrect();
        bool CheckCountryCorrect();
        bool CheckFurnitureCorrect();
    }
}
