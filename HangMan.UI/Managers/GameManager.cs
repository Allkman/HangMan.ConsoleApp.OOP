using HangMan.BL.Managers;
using HangMan.BL.Managers.Interfaces;
using HangMan.DL.Models;
using HangMan.HMServer;
using HangMan.UI.Repositories;
using HangMan.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.UI.Managers
{
    public class GameManager
    {
        private readonly HangManDbContext _dbContext;
        private readonly IUIInteracionRepository _messagesRepository;
        private readonly IPlayerManager _playerManager;
        private readonly List<Topic> _topics;
        private readonly IManageDb _manageDb;
        private readonly IHiddenWordManager _hiddenWordManager;
        public GameManager(HangManDbContext dbContext)
        {
            _dbContext = dbContext;
            dbContext.Database.EnsureCreated();
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
                var word = _wordManager.GetRandomWordInTopic(topic);

                if (word == null)
                {
                    Console.WriteLine("No more Words"); //add to InteractionRepository
                }
                else
                {
                    PlayHangMan(topic, word);
                }

                replay = (Console.ReadKey().KeyChar.ToString().ToUpper() == "T");
                //-------------------------------
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
            _manageDb.GetWordList(topicNumber);
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
       
        private void PlayHangMan(string topic, string word)
        {
            _hiddenWordManager = new HiddenWordManager(word);
            bool guessingAllowed = true;
            _messagesRepository.HangmanPictureMessage(beginLives);
            Console.WriteLine();
            Console.WriteLine(_hiddenWordManager.GetHiddedWordStructure());

            while (guessingAllowed)
            {
                _guess = new Guess(_massageFactory.WordInputMessage(), _hiddenWordManager);

                if (_guess.IsWordGuessed)
                {
                    WordGuessMechanics(zodis);
                    leidziamaSpeti = false;
                }
                else
                {
                    _guess.CheckLetter();

                    if (_hiddenWordManager.IncorrectGuesesCount == maxLives)
                    {
                        _massageFactory.HangmanPictureMessage(maxLives);
                        _massageFactory.LostGameMessage(word.Text);
                        leidziamaSpeti = false;
                    }
                    else
                    {
                        Console.Clear();
                        _massageFactory.HangmanPictureMessage(_hiddenWordManager.IncorrectGuesesCount);
                        _massageFactory.IncorrectLettersListMessage(_hiddenWordManager.HiddenWord.IncorrectGueses);

                        Console.WriteLine(_hiddenWordManager.GetHiddedWordStructure());
                        if (!_hiddenWordManager.HasHiddenLetters)
                        {
                            _massageFactory.WinGameMessage(word.Text);
                            leidziamaSpeti = false;
                        }
                    }
                }
            }
        }
        selectedSubject.Words.Remove(word);
                _playerManager.AddScoreBoard(GetScoreBoard(word, player.PlayerId));
    }
    
}
