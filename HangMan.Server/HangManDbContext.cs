using HangMan.Server.InitialData;
using HangMan.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HangMan.Server
{
    public class HangManDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<LTName> LTNames { get; set; }
        public DbSet<LTCity> LTCities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<PlayerScore> PlayerScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HangManSQLDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(TopicInitData.DataSeed);
            modelBuilder.Entity<LTName>().HasData(NamesInitData.DataSeed);               
            modelBuilder.Entity<LTCity>().HasData(LTUCitiesInitData.DataSeed);               
            modelBuilder.Entity<Country>().HasData(CountriesInitData.DataSeed);               
            modelBuilder.Entity<Furniture>().HasData(FurnitureInitData.DataSeed);               
        }
    }
}
