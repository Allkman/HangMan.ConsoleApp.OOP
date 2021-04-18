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
                
                var topicNumber = 0;
                var word = _manageDb.SelectWordsListToRandom(topic, topicNumber);
                if (word == null) _messagesRepository.NoWordLeftMessage();
                //else
                //{
                //    _hiddenWordManager = new HiddenWordManager(zodis);
                //    bool leidziamaSpeti = true;
                //    _massageFactory.HangmanPictureMessage(beginLives);
                //    Console.WriteLine();
                //    Console.WriteLine(_hiddenWordManager.GetHiddedWordStructure());

                //    while (leidziamaSpeti)
                //    {
                //        _guess = new Guess(_massageFactory.WordInputMessage(), _hiddenWordManager);

                //        if (_guess.IsWordGuessed)
                //        {
                //            WordGuessMechanics(zodis);
                //            leidziamaSpeti = false;
                //        }
                //        else
                //        {
                //            _guess.CheckLetter();

                //            if (_hiddenWordManager.IncorrectGuesesCount == maxLives)
                //            {
                //                _massageFactory.HangmanPictureMessage(maxLives);
                //                _massageFactory.LostGameMessage(zodis.Text);
                //                leidziamaSpeti = false;
                //            }
                //            else
                //            {
                //                Console.Clear();
                //                _massageFactory.HangmanPictureMessage(_hiddenWordManager.IncorrectGuesesCount);
                //                _massageFactory.IncorrectLettersListMessage(_hiddenWordManager.HiddenWord.IncorrectGueses);

                //                Console.WriteLine(_hiddenWordManager.GetHiddedWordStructure());
                //                if (!_hiddenWordManager.HasHiddenLetters)
                //                {
                //                    _massageFactory.WinGameMessage(zodis.Text);
                //                    leidziamaSpeti = false;
                //                }
                //            }
                //        }
                //    }
                //}
                //selectedSubject.Words.Remove(zodis);
                //_playerManager.AddScoreBoard(GetScoreBoard(zodis, user.PlayerId));
                //replay = _messageRepository.RepeatGameMessage();
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
            for (int i = 0; i < _topics.Count; i++)
            {
                Console.Write("\n {0} - {1}", i + 1, _topics[i].Name);
            }
            Console.WriteLine();
        }
    }    
}
