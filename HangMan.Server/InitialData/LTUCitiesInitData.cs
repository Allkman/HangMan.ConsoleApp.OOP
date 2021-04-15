using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.Server.InitialData
{
    public class LTUCitiesInitData
    {
        public static LTCity[] DataSeed => new LTCity[]
       {
            new LTCity { LTCityId = 1, TopicId =2, Text = "Klaipėda"},
            new LTCity { LTCityId = 2, TopicId =2, Text = "Kaunas"},
            new LTCity { LTCityId = 3, TopicId =2, Text = "Vilnius"},
            new LTCity { LTCityId = 4, TopicId =2, Text = "Ukmergė"},
            new LTCity { LTCityId = 5, TopicId =2, Text = "Tauragė"},
            new LTCity { LTCityId = 6, TopicId =2, Text = "Palanga"},
            new LTCity { LTCityId = 7, TopicId =2, Text = "Utena"},
            new LTCity { LTCityId = 8, TopicId =2, Text = "Raseiniai"},
            new LTCity { LTCityId = 9, TopicId =2, Text = "Varėna"},
            new LTCity { LTCityId = 10, TopicId =2, Text = "Alytus"},
       };
   }
}
