using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.BL.Managers.Interfaces
{
    public interface IManageDb
    {
        List<Topic> GetAllTopics();
        void RemoveWordFromSeletedWordsList(int topicNumber);
        int SelectWordsList(int topicNumber);
        string SelectWordsListToRandom(Topic topic, int topicNumber);
    }
}
