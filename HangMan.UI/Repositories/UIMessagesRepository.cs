using System;
using System.Collections.Generic;
using System.Text;
using Colorify;
using Colorify.UI;
using HangMan.UI.Repositories.Interfaces;

namespace HangMan.UI.Repositories
{

    public class UIMessagesRepository : IUIMessagesRepository
    {
        public static Format _colorify { get; set; } //ConsoleApp UI 
        public int GreetingMessage()
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

    }
}
