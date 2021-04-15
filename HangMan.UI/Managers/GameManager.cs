using HangMan.DL.Models;
using HangMan.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.UI.Managers
{
    public class GameManager
    {
        private readonly IUIMessagesRepository _uiMessagesRepository;

        List<UsedWord> panaudotiZodziai = new List<UsedWord>();

        public GameManager(IUIMessagesRepository uiMessagesRepository)
        {
            _uiMessagesRepository = uiMessagesRepository;
        }

        public void BeginGame()
        {

        }
    }
}
