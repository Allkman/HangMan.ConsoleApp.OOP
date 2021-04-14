using HangMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.Data.InitialData
{
    public class TopicInitData
    {
        public static Topic[] DataSeed => new Topic[]
       {
           new Topic { TopicId = 1, Name = "Names" },
           new Topic { TopicId = 1, Name = "Lithuanian cities" },
           new Topic { TopicId = 1, Name = "Countries" },
           new Topic { TopicId = 1, Name = "Furniture" }
       };
    }
}
