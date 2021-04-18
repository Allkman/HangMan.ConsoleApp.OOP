using HangMan.HMServer;
using System;
using Colorify;
using static Colorify.Colors;
using Colorify.UI;
using ToolBox.Platform;
using HangMan.UI.Managers.Interfaces;
using HangMan.UI.Managers;

namespace HangMan.UI
{
    static class Program
    {
        public static Format _colorify { get; set; } //ConsoleApp UI 
        static void Main(string[] args)
        {
            var context = new HangManDbContext();
            context.Database.EnsureCreated();
            _colorify = new Format(Theme.Light);
            IGameManager gameManager = new GameManager();

        }  
    }
}