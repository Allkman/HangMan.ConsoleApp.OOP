using HangMan.BL.Managers.Interfaces;
using HangMan.DL.Models;
using HangMan.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.UI.Managers
{
    public class GameManager
    {
        private readonly IUIInteracionRepository _messagesRepository;
        private readonly IPlayerManager _playerManager;
        private readonly List<Topic> _topics;
        List<UsedWord> usedWords = new List<UsedWord>();
        private readonly IWordManager _wordManager;
        public GameManager(IUIInteracionRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
            _topics = _wordManager.GetAllTopics();
        }

        public void BeginGame()
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
                var word = _wordManager.GetRandomWordInTopic(topic);
                if (word == null)
                {
                    Console.WriteLine("No more Words"); //add to InteractionRepository
                }
                else
                {
                   // PlayGame(topic, word);
                }
                replay = (Console.ReadKey().KeyChar.ToString().ToUpper() == "T");
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
            return _topics[topicNumber - 1];
        }
        private void DisplayTopicNames()
        {
            for (int i = 1; i <= _topics.Count; i++)
            {
                Console.Write("\n {0} - {1}", i+1, _topics[i].Name);
            }
            Console.WriteLine();
        }
        
    }
}
