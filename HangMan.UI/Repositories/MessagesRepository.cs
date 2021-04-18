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
    }
}
