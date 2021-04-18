using HangMan.BL.Managers;
using HangMan.BL.Managers.Interfaces;
using HangMan.DL.Models;
using HangMan.HMServer;
using HangMan.UI.Managers.Interfaces;
using HangMan.UI.Repositories;
using HangMan.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.UI.Managers
{
    public class GameManager : IGameManager
    {
   
        private readonly IMessagesRepository _messagesRepository;
        private readonly IPlayerManager _playerManager;
        private readonly List<Topic> _topics;
        private readonly IManageDb _manageDb;
        private readonly IHiddenWordManager _hiddenWordManager;
        public GameManager(IPlayerManager playerManager, IMessagesRepository messagesRepository, IManageDb manageDb)
        {
            _playerManager = playerManager;
            _messagesRepository = messagesRepository;
            _manageDb = manageDb;
            
            _topics = _manageDb.GetAllTopics();

        }

        public void PlayerLogin()
        {
            var playerName = _messagesRepository.LoginMessage();
            var player = _playerManager.GetPlayerByPlayerName(playerName);
            if (player == null)
            {
                player = _playerManager.GetById(_playerManager.CreatePlayer(new Player { PlayerName = playerName }));
            }
            _messagesRepository.PlayerStatisticsMessage(player);
            StartHangMan();
        }

        private void StartHangMan()
        {
            bool replay = true;
            while (replay)
            {
                Console.Clear();

                var topic = TopicSelection();
                //var word = _manageDb.GetRandomWordInTopic(topic);

            }
        }

        private Topic TopicSelection()
        {
            _messagesRepository.SelectTopicMessage();
            var topicNumber = 0;
            DisplayTopicNames();
            while (topicNumber > _topics.Count || topicNumber == 0)
            {
                var topicInput = Console.ReadKey().KeyChar;
                int.TryParse(topicInput.ToString(), out topicNumber);
                if (topicNumber > _topics.Count || topicNumber == 0)
                {
                    _messagesRepository.IncorrectTopictMessage(topicNumber.ToString());
                }
            }
            Console.Clear();
            _messagesRepository.CorrectTopicMessage(_topics[topicNumber - 1].Name);
            _manageDb.SelectWordsList(topicNumber);
            return _topics[topicNumber - 1];
        }

        private void DisplayTopicNames()
        {
            for (int i = 0; i < _topics.Count; i++)
            {
                Console.Write("\n {0} - {1}", i + 1, _topics[i].Name);
            }
            Console.WriteLine();
        }
    }    
}
