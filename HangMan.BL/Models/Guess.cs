using HangMan.BL.Managers.Interfaces;
using HangMan.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.BL.Models
{
    public class Guess : IGuess
    {
        private readonly string _guess;
        private readonly IHiddenWordManager _hiddenWordManager;

        public Guess(string guess, IHiddenWordManager hiddenWordManager)
        {
            _guess = guess;
            _hiddenWordManager = hiddenWordManager;
        }

        public bool IsWordGuessed => _guess.Length > 1;
        private void CheckSelectedWordIsCorrect(int topicNumber)
        {
            switch(topicNumber)
                {
                case 0:
                    CheckLTNameCorrect();
                    break;
                case 1:
                    CheckLTCityCorrect();
                    break;
                case 2:
                    CheckCountryCorrect();
                    break;
                case 3:
                    CheckFurnitureCorrect();
                    break;
            }
        }        
        public bool CheckLTNameCorrect()
        {
            var isCorrect = _hiddenWordManager.LTName.Text.ToUpper() == _guess.ToUpper();
            if (isCorrect) _hiddenWordManager.HiddenWord.CorrectGueses = _hiddenWordManager.LTName.Text.Select(x => x.ToString()).ToArray();
            return isCorrect;
        }
        public bool CheckLTCityCorrect()
        {
            var isCorrect = _hiddenWordManager.LTCity.Text.ToUpper() == _guess.ToUpper();
            if (isCorrect) _hiddenWordManager.HiddenWord.CorrectGueses = _hiddenWordManager.LTCity.Text.Select(x => x.ToString()).ToArray();
            return isCorrect;
        }
        public bool CheckCountryCorrect()
        {
            var isCorrect = _hiddenWordManager.Country.Text.ToUpper() == _guess.ToUpper();
            if (isCorrect) _hiddenWordManager.HiddenWord.CorrectGueses = _hiddenWordManager.Country.Text.Select(x => x.ToString()).ToArray();
            return isCorrect;
        }
        public bool CheckFurnitureCorrect()
        {
            var isCorrect = _hiddenWordManager.Furniture.Text.ToUpper() == _guess.ToUpper();
            if (isCorrect) _hiddenWordManager.HiddenWord.CorrectGueses = _hiddenWordManager.Furniture.Text.Select(x => x.ToString()).ToArray();
            return isCorrect;
        }
        private void CheckLetterOfSelectedWord(int topicNumber)
        {
            switch(topicNumber)
            {
                case 0:
                    CheckLTNameLetter();
                    break;
                case 1:
                    CheckLTCityLetter();
                    break;
                case 2:
                    CheckCountryLetter();
                    break;
                case 3:
                    CheckFurnitureLetter();
                    break;
            }
        }
        public void CheckLTNameLetter()
        {
            if (_hiddenWordManager.HiddenWord.IsLetterGuessed(_guess)) return;

            var wordArray = _hiddenWordManager.LTName.Text.ToCharArray();
            var letterIndexes = new List<int>();
            for (int i = 0; i < _hiddenWordManager.LTName.Text.Length; i++)
            {
                if (wordArray[i].ToString().ToUpper() == _guess.ToUpper()) letterIndexes.Add(i);
            }

            if (letterIndexes.Count == 0)
                _hiddenWordManager.AddIncorrectLetter(_guess);
            else
                _hiddenWordManager.AddCorrectLetter(_guess, letterIndexes);
        }
        public void CheckLTCityLetter()
        {
            if (_hiddenWordManager.HiddenWord.IsLetterGuessed(_guess)) return;

            var wordArray = _hiddenWordManager.LTCity.Text.ToCharArray();
            var letterIndexes = new List<int>();
            for (int i = 0; i < _hiddenWordManager.LTCity.Text.Length; i++)
            {
                if (wordArray[i].ToString().ToUpper() == _guess.ToUpper()) letterIndexes.Add(i);
            }

            if (letterIndexes.Count == 0)
                _hiddenWordManager.AddIncorrectLetter(_guess);
            else
                _hiddenWordManager.AddCorrectLetter(_guess, letterIndexes);
        }
        public void CheckCountryLetter()
        {
            if (_hiddenWordManager.HiddenWord.IsLetterGuessed(_guess)) return;

            var wordArray = _hiddenWordManager.Country.Text.ToCharArray();
            var letterIndexes = new List<int>();
            for (int i = 0; i < _hiddenWordManager.Country.Text.Length; i++)
            {
                if (wordArray[i].ToString().ToUpper() == _guess.ToUpper()) letterIndexes.Add(i);
            }

            if (letterIndexes.Count == 0)
                _hiddenWordManager.AddIncorrectLetter(_guess);
            else
                _hiddenWordManager.AddCorrectLetter(_guess, letterIndexes);
        }
        public void CheckFurnitureLetter()
        {
            if (_hiddenWordManager.HiddenWord.IsLetterGuessed(_guess)) return;

            var wordArray = _hiddenWordManager.Furniture.Text.ToCharArray();
            var letterIndexes = new List<int>();
            for (int i = 0; i < _hiddenWordManager.Furniture.Text.Length; i++)
            {
                if (wordArray[i].ToString().ToUpper() == _guess.ToUpper()) letterIndexes.Add(i);
            }

            if (letterIndexes.Count == 0)
                _hiddenWordManager.AddIncorrectLetter(_guess);
            else
                _hiddenWordManager.AddCorrectLetter(_guess, letterIndexes);
        }
    }
}
