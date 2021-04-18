using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.UI.Repositories.Interfaces
{
    public interface IMessagesRepository
    {
        void CorrectTopicMessage(string topicName);
        void IncorrectTopictMessage(string topicNumber);
        string LoginMessage();
        int PlayerGreetingMessage();
        void PlayerStatisticsMessage(Player player);
        void SelectTopicMessage();
    }
}
