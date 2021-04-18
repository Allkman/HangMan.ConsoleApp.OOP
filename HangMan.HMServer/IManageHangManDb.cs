using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.HMServer
{
    public interface IManageHangManDb
    {
        List<LTCity> GetCities();
        List<Country> GetCountries();
        List<Furniture> GetFurnitures();
        List<LTName> GetNames();
        int GetTopicWords(int topicId);
    }
}
