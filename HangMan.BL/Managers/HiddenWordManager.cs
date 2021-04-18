using HangMan.BL.Managers.Interfaces;
using HangMan.BL.Models;
using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.BL.Managers
{
    public class HiddenWordManager : IHiddenWordManager
    {
        public LTName LTName { get; }
        public LTCity LTCity { get; }
        public Country Country { get; }
        public Furniture Furniture { get; }


        public HiddenWord HiddenWord { get; set; }


        public int IncorrectGuesesCount => HiddenWord.IncorrectGueses.Count;
        public bool HasHiddenLetters => HiddenWord.HiddenLetterCount > 0;        

        public HiddenWordManager()
        {
            //TODO show word from selected topic
            HiddenWord = new HiddenWord(LTName.Text.Length);
            HiddenWord = new HiddenWord(LTCity.Text.Length);
            HiddenWord = new HiddenWord(Country.Text.Length);
            HiddenWord = new HiddenWord(Furniture.Text.Length);
        }

        public string GetHiddedWordStructure()
        {

            var sb = new StringBuilder("Zodis: ");
            foreach (var raide in HiddenWord.CorrectGueses)
            {
                if (string.IsNullOrWhiteSpace(raide)) sb.Append("_ ");
                else sb.Append($"{raide} ");
            }
            return sb.ToString();
        }

        public void AddCorrectLetter(string guessedLetter, List<int> raidesIndeksai)
        {
            foreach (int indeksas in raidesIndeksai)
            {
                HiddenWord.CorrectGueses[indeksas] = guessedLetter;
            }
        }

        /// <summary>
        /// Pridedama neteisingai spėta raidė
        /// </summary>
        public void AddIncorrectLetter(string guessedLetter)
        {
            HiddenWord.IncorrectGueses.Add(guessedLetter);
        }
    }
}
