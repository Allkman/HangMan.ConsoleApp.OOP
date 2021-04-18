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

namespace HangMan.BL.Managers
{
    public class ManageDb : IManageDb
    {
        private readonly HangManDbContext _dbContext;
        public LTName LTName { get; set; }
        public LTCity LTCity { get; set; }
        public Country Country { get; set; }
        public Furniture Furniture { get; set; }
        public Word Word { get; set; }
        public Topic Topic { get; set; }


        private delegate List<Word> TopicDelegate();
        private delegate Word WordsDelegate();

        
        public ManageDb(HangManDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public List<Topic> GetAllTopics()
        {
            List<Topic> list;
            list = _dbContext.Topics.ToList();
            return list;
        }
        public List<LTName> GetLTNames()
        {
            List<LTName> list = new List<LTName>();
            list = _dbContext.LTNames.ToList();//.Include(z => z.PlayerScores).Include(z => z.Topic) ??   
            return list;
        }
        public List<LTCity> GetLTCities()
        {
            List<LTCity> list = new List<LTCity>();
            list = _dbContext.LTCities.ToList();
            return list;
        }
        public List<Country> GetCountries()
        {
            List<Country> list = new List<Country>();
            list = _dbContext.Countries.ToList();
            return list;
        }
        public List<Furniture> GetFurnitures()
        {
            List<Furniture> list = new List<Furniture>();
            list = _dbContext.Furnitures.ToList();
            return list;
        }

        public void SelectWordsList(int topicNumber)
        {
            Dictionary<int, Lazy<TopicDelegate>> strategy = new Dictionary<int, Lazy<TopicDelegate>>
            {
                {1, new Lazy<TopicDelegate>(() => GetLTNames )},
                {2, new Lazy<TopicDelegate>(() => GetLTCities)},
                {3, new Lazy<TopicDelegate>(() => GetCountries)},
                {4, new Lazy<TopicDelegate>(() => GetFurnitures)},
            };
            strategy[topicNumber].Value.Invoke();
        }
        public Word SelectWordsListRandomizer(int topicNumber)
        {
            Topic topic;
            Dictionary<int, Lazy<WordsDelegate>> strategy = new Dictionary<int, Lazy<WordsDelegate>>
            {
                {1, new Lazy<WordsDelegate>(() => GetRandomWordInLTName(topic)},
                {2, new Lazy<WordsDelegate>(() => GetRandomWordInLTCity(topic))},
                {3, new Lazy<WordsDelegate>(() => GetRandomWordInCountry(topic))},
                {4, new Lazy<WordsDelegate>(() => GetRandomWordInFurniture(topic))},
            };
            return strategy[topicNumber].Value.Invoke;
        }
        public LTName GetRandomWordInLTName(Topic topic)
        {
            IRandomExtension _rndExtension = new RandomExtension();
            var words = topic.LTNames;            
            if (words.Count == 0) return null;
            var randomNumber = _rndExtension.Random(0, words.Count);
            return words[randomNumber];
        }
        public LTCity GetRandomWordInLTCity(Topic topic)
        {
            IRandomExtension _rndExtension = new RandomExtension();
            var words = topic.LTCities;
            if (words.Count == 0) return null;
            var randomNumber = _rndExtension.Random(0, words.Count);
            return words[randomNumber];
        }
        public Country GetRandomWordInCountry(Topic topic)
        {
            IRandomExtension _rndExtension = new RandomExtension();
            var words = topic.Countries;
            if (words.Count == 0) return null;
            var randomNumber = _rndExtension.Random(0, words.Count);
            return words[randomNumber];
        }
        public Furniture GetRandomWordInFurniture(Topic topic)
        {
            IRandomExtension _rndExtension = new RandomExtension();
            var words = topic.Furnitures;
            if (words.Count == 0) return null;
            var randomNumber = _rndExtension.Random(0, words.Count);
            return words[randomNumber];
        }
    }
}
