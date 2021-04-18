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
        public int SelectWordsList(int topicNumber)
        {
            Console.Clear();
           switch(topicNumber)
            { 
                case 0:
                    GetLTNames();
                    break;
                case 1:
                    GetLTCities();
                    break;
                case 2:
                    GetCountries();
                    break;
                case 3:
                    GetFurnitures();
                    break;
            }
            return topicNumber;
        }
        public string SelectWordsListToRandom(Topic topic, int topicNumber)
        {

            Console.Clear();
            switch (topicNumber)
            {
                case 0:
                    GetRandomWordInLTName(topic);
                    break;
                case 1:
                    GetRandomWordInLTCity(topic);
                    break;
                case 2:
                    GetRandomWordInCountry(topic);
                    break;
                case 3:
                    GetRandomWordInFurniture(topic);
                    break;
            }
            return topic.ToString();
        }
        public List<Topic> GetAllTopics()
        {
            List<Topic> list;
            list = _dbContext.Topics.ToList();
            return list;
        }
        public List<LTName> GetLTNames()
        {
            List<LTName> list;
            list = _dbContext.LTNames.ToList();//.Include(z => z.PlayerScores).Include(z => z.Topic) ??   
            return list;
        }
        public List<LTCity> GetLTCities()
        {
            List<LTCity> list;
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
