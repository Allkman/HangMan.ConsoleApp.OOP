using HangMan.Data.InitialData;
using HangMan.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HangMan.Data
{
    public class HangManDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<PlayerScore> PlayerScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HangManSQLDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(Topics);
            modelBuilder.Entity<Topic>().HasData(Words);               
        }
    }
}
