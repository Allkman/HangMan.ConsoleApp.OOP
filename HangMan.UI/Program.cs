using HangMan.Server;
using System;
using Colorify;
using static Colorify.Colors;
using Colorify.UI;
using ToolBox.Platform;
namespace HangMan.UI
{
    static class Program
    {
        public static Format _colorify { get; set; } //ConsoleApp UI 
        
        const int choiceStatistika = 1;
        const int choiceZaidimas = 2;

        static void Main(string[] args)
        {
            _colorify = new Format(Theme.Light);
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
                if (choiceNumber == 0) Console.WriteLine("\nKlaida! Galima įvesti tik skaičių. Bandykite iš naujo");

            }
        }  
    }
}