using HangMan.BL.Models;
using HangMan.DL.Models;
using System.Collections.Generic;

namespace HangMan.BL.Managers.Interfaces
{
    public interface IWordManager
    {
        List<Topic> GetAllTopics();
        Word GetRandomWordInTopic(Topic topic);
    }
}
