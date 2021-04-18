using HangMan.HMServer;
using System;
using Colorify;
using static Colorify.Colors;
using Colorify.UI;
using ToolBox.Platform;
using HangMan.UI.Managers.Interfaces;
using HangMan.UI.Managers;
using HangMan.BL.Managers.Interfaces;
using HangMan.BL.Managers;
using HangMan.UI.Repositories.Interfaces;
using HangMan.UI.Repositories;

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
            
            //-----Dependancy injection-------
            IPlayerManager playerRepository = new PlayerManager(context);            
            IMessagesRepository messagesRepository = new MessagesRepository();
            IManageDb manageDb = new ManageDb(context);
            IGameManager gameManager = new GameManager(playerRepository, messagesRepository, manageDb);
            //--------------------------------
            gameManager.PlayerLogin();
        }  
    }
}