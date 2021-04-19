using HangMan.DL.Models;

namespace HangMan.BL.Managers.Interfaces
{
    public interface IPlayerManager
    {
        void AddPlayerScore(PlayerScore playerScore);
        int CreatePlayer(Player player);
        Player GetById(int id);
        Player GetPlayerByPlayerName(string playerName);
    }
}
