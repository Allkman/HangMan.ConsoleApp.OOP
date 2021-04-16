using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HangMan.DL.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        [Required]
        public string Name { get; set; }        
        public virtual List<LTName> LTNames { get; set; }
        public virtual List<LTCity> LTCities { get; set; }
        public virtual List<Country> Countries { get; set; }
        public virtual List<Furniture> Furnitures { get; set; }
        //public virtual List<PlayerScore> PlayerScores { get; set; }

        //public  List<Topic> GetTopicsWords => new List<Topic>
        //{
        //    new Topic { Name = "NAMES", LTNames = new List<LTName>() },
        //    new Topic { Name = "LITHUANIAN CITIES", LTCities = new List<LTCity>() },
        //    new Topic { Name = "COUNTRIES", Countries = new List<Country>() },
        //    new Topic { Name = "FURNITURE", Furnitures = new List<Furniture>() }
        //};

       
    }
}
