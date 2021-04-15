using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.Server.InitialData
{
    public class TopicInitData
    {
        public static Topic[] DataSeed => new Topic[]
       {
           new Topic { TopicId = 1, Name = "Names" },
           new Topic { TopicId = 2, Name = "Lithuanian cities" },
           new Topic { TopicId = 3, Name = "Countries" },
           new Topic { TopicId = 4, Name = "Furniture" }
       };
    }
}
