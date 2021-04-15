using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.Server.InitialData
{
    public class NamesInitData
    {
        public static LTName[] DataSeed => new LTName[]
        {
            new LTName { LTNameId = 1, TopicId = 1, Text = "Gediminas"},
            new LTName { LTNameId = 2, TopicId =1, Text = "Mindaugas"},
            new LTName { LTNameId = 3, TopicId =1, Text = "Vytautas"},
            new LTName { LTNameId = 4, TopicId =1, Text = "Kęstutis"},
            new LTName { LTNameId = 5, TopicId =1, Text = "Algirdas"},
            new LTName { LTNameId = 6, TopicId =1, Text = "Žygimantas"},
            new LTName { LTNameId = 7, TopicId =1, Text = "Birutė"},
            new LTName { LTNameId = 8, TopicId =1, Text = "Barbora"},
            new LTName { LTNameId = 9, TopicId =1, Text = "Augustas"},
            new LTName { LTNameId = 10, TopicId =1, Text = "Morta"},
        };
    }
}
