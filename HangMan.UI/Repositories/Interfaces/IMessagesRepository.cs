using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.UI.Repositories.Interfaces
{
    public interface IMessagesRepository
    {
        void CorrectTopicMessage(string topicName);
        void HangmanPictureMessage(int incorrectGuessCount);
        void IncorrectLettersListMessage(List<string> neteisingiSpejimai);
        void IncorrectTopictMessage(string topicNumber);
        string LoginMessage();
        void LostGameMessage(string word);
        void NoWordLeftMessage();
        int PlayerGreetingMessage();
        void PlayerStatisticsMessage(Player player);
        bool RepeatGameMessage();
        void SelectTopicMessage();
        void WinGameMessage(string word);
        string WordInputMessage();
    }
}
