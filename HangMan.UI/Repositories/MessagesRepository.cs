using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Colorify;
using Colorify.UI;
using HangMan.DL.Models;
using HangMan.UI.Repositories.Interfaces;

namespace HangMan.UI.Repositories
{

    public class MessagesRepository : IMessagesRepository
    {
        public static Format _colorify { get; set; } //ConsoleApp UI 
        private readonly HangerUIRepository _hangerUI;

        public MessagesRepository()
        {
            _hangerUI = new HangerUIRepository();
        }

        public int PlayerGreetingMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to a HangMan Game");
            Console.WriteLine("Choose what you want to do");
            Console.WriteLine("");
            Console.WriteLine("1. View Statistics ");
            Console.WriteLine("2. Play Game");

            int choiceNumber = 0;
            while (choiceNumber == 0)
            {
                var choice = Console.ReadKey().KeyChar;
                int.TryParse(choice.ToString(), out choiceNumber);
                if (choiceNumber == 0) Console.WriteLine("\nWrong input! Only numbers allowed, Try again");

            }
            return choiceNumber;
        }
        public string LoginMessage()
        {
            Console.Clear();
            Console.WriteLine("Enter your name: ");
            Console.WriteLine("");
            return Console.ReadLine();
        }
        public void NoWordLeftMessage()
        {
            Console.WriteLine("No more words in current topic, would you like to choose another topic? Y/N ?");
        }
        public void PlayerStatisticsMessage(Player player)
        {
            Console.WriteLine($"Player {player.PlayerName} played {player.PlayerScores.Count} times");
            Console.WriteLine($"And won {player.PlayerScores.Count(z => z.IsCorrect)} times");
            Console.WriteLine("");
            Console.WriteLine("-= Press any key to continue =-");
            Console.ReadKey();
        }
        public void SelectTopicMessage()
        {
            Console.WriteLine("Select topic: ");
        }
        public void IncorrectTopictMessage(string topicNumber)
        {
            Console.WriteLine("\n {0} no such topic, try again", topicNumber);
        }
        public void CorrectTopicMessage(string topicName)
        {
            Console.WriteLine("\n Topic: {0}", topicName);
        }
        public void HangmanPictureMessage(int incorrectGuessCount)
        {
            _hangerUI.DisplayPicture(incorrectGuessCount);
        }
        public bool RepeatGameMessage()
        {
            Console.WriteLine("Replay game: Y/N?");
            return Console.ReadKey().KeyChar.ToString().ToUpper() == "Y";
        }
        public string WordInputMessage()
        {
            Console.WriteLine("\n\nSpėkite raidę ar žodį:");
            return Console.ReadLine();
        }
        public void WinGameMessage(string word)
        {
            Console.WriteLine();
            Console.WriteLine("[[=== Congratulation ===]]");
            Console.WriteLine(" Word is correct ");
            Console.WriteLine();
            Console.WriteLine("Word was: {0}", word);
        }
        public void LostGameMessage(string word)
        {
            Console.WriteLine();
            Console.WriteLine(" You lost ");
            Console.WriteLine(("Word was: {0}", word));
        }
        public void IncorrectLettersListMessage(List<string> incorrectGuesses)
        {
            Console.Write("\nGuessed letters: ");
            foreach (var incorrectGuess in incorrectGuesses)
            {
                Console.Write($"{incorrectGuess} ");
            }
        }
    }
}
