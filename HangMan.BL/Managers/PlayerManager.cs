using HangMan.BL.Managers.Interfaces;
using HangMan.DL.Models;
using HangMan.HMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.BL.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly HangManDbContext _dbContext;

        public PlayerManager(HangManDbContext dbContext)
        {
            _dbContext = dbContext;
            dbContext.Database.EnsureCreated();
        }
        public int CreatePlayer(Player player)
        {
            _dbContext.Players.Add(player);
            _dbContext.SaveChanges();
            return player.PlayerId;
        }
        public Player GetById(int id)
        {
            var player = _dbContext.Players.Where(z => z.PlayerId == id).Include(z => z.PlayerScores).FirstOrDefault();
            return player;
        }
        public Player GetPlayerByPlayerName(string playerName)
        {
            var player = _dbContext.Players.SingleOrDefault(p => p.PlayerName == playerName);
            return player;
        }
    }
}
