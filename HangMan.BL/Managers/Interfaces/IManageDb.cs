using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.BL.Managers.Interfaces
{
    public interface IManageDb
    {
        List<Topic> GetAllTopics();
        int SelectWordsList(int topicNumber);
        int SelectWordsListToRandom(Topic topic, int topicNumber);
    }
}
