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

    public class UIInteractionRepository : IUIInteracionRepository
    {
        public static Format _colorify { get; set; } //ConsoleApp UI 
        public int PlayerGreetingMessage()
        {
            _colorify.Clear();
            _colorify.WriteLine("Welcome to a HangMan Game");
            _colorify.WriteLine("Choose what you want to do");
            _colorify.WriteLine("");
            _colorify.WriteLine("1. View Statistics ");
            _colorify.WriteLine("2. Play Game");

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
            _colorify.Clear();
            _colorify.WriteLine("Enter your name: ");
            _colorify.WriteLine("");
            return Console.ReadLine();
        }
        public void PlayerStatisticsMessage(Player player)
        {
            _colorify.WriteLine($"Player {player.PlayerName} played {player.PlayerScores.Count} times");
            _colorify.WriteLine($"And won {player.PlayerScores.Count(z => z.IsCorrect)} times");
            _colorify.WriteLine("");
            _colorify.WriteLine("-= Press any key to continue =-");
            Console.ReadKey();
        }
        public void SelectTopicMessage()
        {
            _colorify.WriteLine("Select topic: ");
        }
        public void IncorrectTopictMessage(string topicNumber)
        {
            _colorify.WriteLine("\n {0} no such topic, try again", topicNumber);
        }
        public void CorrectTopicMessage(string topicName)
        {
            Console.WriteLine("\n Topic: {0}", topicName);
        }
    }
}
