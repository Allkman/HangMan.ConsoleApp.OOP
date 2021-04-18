using HangMan.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.HMServer
{
    public class ManageHangManDb : IManageHangManDb
    {
        private readonly HangManDbContext _dbContext;

        public ManageHangManDb(HangManDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<LTName> GetNames()
        {
            List<LTName> ltNames;
            ltNames = _dbContext.LTNames.Include(n => n.TopicId).ToList();
            return ltNames;
        }
        public List<LTCity> GetCities()
        {
            List<LTCity> lTCities;
            lTCities = _dbContext.LTCities.Include(n => n.TopicId).ToList();
            return lTCities;
        }
        public List<Country> GetCountries()
        {
            List<Country> countries;
            countries = _dbContext.Countries.Include(n => n.TopicId).ToList();
            return countries;
        }
        public List<Furniture> GetFurnitures()
        {
            List<Furniture> furnitures;
            furnitures = _dbContext.Furnitures.Include(n => n.TopicId).ToList();
            return furnitures;
        }



        public int GetTopicWords(int topicId)
        {
            Console.Clear();
            switch(topicId)
            {
                case 0:
                    GetNames();
                    break;
                case 1:
                    GetCities();
                    break;
                case 2:
                    GetCountries();
                    break;
                case 3:
                    GetFurnitures();
                    break;
            }
            return topicId;
        }
    }
}
