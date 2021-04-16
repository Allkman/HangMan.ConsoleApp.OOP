using HangMan.BL.Helpers;
using HangMan.BL.Helpers.Interfaces;
using HangMan.BL.Managers.Interfaces;
using HangMan.BL.Models;
using HangMan.DL.Models;
using HangMan.HMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.BL.Managers
{
    public class WordManager : IWordManager
    {
        private readonly HangManDbContext _dbContext;

        public WordManager(HangManDbContext dbContext)
        {
            _dbContext = dbContext;
            dbContext.Database.EnsureCreated();
        }
        public List<Topic> GetAllTopics()
        {


            List<Topic> topicsList = new List<Topic>();
            foreach (var topic in topicsList)
            {
                topic.Add
            }
            list = _dbContext.Topics.ToList();
            return list;
        }

        public Word GetRandomWordInTopic(Topic topic)
        {
            IRandomExtension _randomExtension = new RandomExtension();
           
            var words = topic.


            //jeigu temoje neliko zodziu
            if (words.Count == 0) return null;
            var randomNumbr = _randomExtension.Random(0, words.Count);
            return words[randomNumbr];
        }
    }
}
}
