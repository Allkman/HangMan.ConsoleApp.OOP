using HangMan.BL.Managers;
using HangMan.BL.Managers.Interfaces;
using HangMan.BL.Models;
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
        LTName ltName = new LTName();
        LTCity ltCity = new LTCity();
        Country country = new Country();
        Furniture furniture = new Furniture();
        Player player = new Player();
        private readonly IMessagesRepository _messagesRepository;
        private readonly IPlayerManager _playerManager;
        private readonly List<Topic> _topics;
        private readonly IManageDb _manageDb;
        public  IHiddenWordManager _hiddenWordManager;
        private IGuess _guess;
        const int beginLives = 0;
        const int maxLives = 7;
        public GameManager(IPlayerManager playerManager, IMessagesRepository messagesRepository, IManageDb manageDb, IHiddenWordManager hiddenWordManager)
        {
            _playerManager = playerManager;
            _messagesRepository = messagesRepository;
            _manageDb = manageDb;
            _hiddenWordManager = hiddenWordManager;
            _topics = _manageDb.GetAllTopics();
            
        }

        public void PlayerLogin()
        {
            var playerName = _messagesRepository.LoginMessage();
            player = _playerManager.GetPlayerByPlayerName(playerName);
            if (player == null)
            {
                player = _playerManager.GetById(_playerManager.CreatePlayer(new Player { PlayerName = playerName }));
            }
            _messagesRepository.PlayerStatisticsMessage(player);
            StartHangMan();
        }

        public void StartHangMan()
        {
           
            bool replay = true;
            while (replay)
            {
                Console.Clear();

                var topic = TopicSelection();
                
                var topicNumber = 0;
                var word = _manageDb.SelectWordsListToRandom(topic, topicNumber);
                if (word == null) _messagesRepository.NoWordLeftMessage();
                else
                {
                    _hiddenWordManager = new HiddenWordManager(ltName, ltCity, country, furniture);
                    bool guessingAllowed = true;
                    _messagesRepository.HangmanPictureMessage(beginLives);
                    Console.WriteLine();
                    Console.WriteLine(_hiddenWordManager.GetHiddedWordStructure());

                    while (guessingAllowed)
                    {
                        _guess = new Guess(_messagesRepository.WordInputMessage(), _hiddenWordManager);

                        if (_guess.IsWordGuessed)
                        {
                            SelectedWordGuessMechanics(topicNumber);
                            guessingAllowed = false;
                        }
                        else
                        {
                            _guess.CheckSelectedWordIsCorrect(topicNumber);

                            if (_hiddenWordManager.IncorrectGuesesCount == maxLives)
                            {
                                _messagesRepository.HangmanPictureMessage(maxLives);
                                _messagesRepository.LostGameMessage(word);
                                guessingAllowed = false;
                            }
                            else
                            {
                                Console.Clear();
                                _messagesRepository.HangmanPictureMessage(_hiddenWordManager.IncorrectGuesesCount);
                                _messagesRepository.IncorrectLettersListMessage(_hiddenWordManager.HiddenWord.IncorrectGueses);

                                Console.WriteLine(_hiddenWordManager.GetHiddedWordStructure());
                                if (!_hiddenWordManager.HasHiddenLetters)
                                {
                                    _messagesRepository.WinGameMessage(word);
                                    guessingAllowed = false;
                                }
                            }
                        }
                    }
                }
                _manageDb.RemoveWordFromSeletedWordsList(topicNumber);               
                SelectPlayerScoreBoard(topicNumber);
                _playerManager.AddPlayerScore(SelectPlayerScoreBoard(topicNumber));
                replay = _messagesRepository.RepeatGameMessage();
            }        
        }
        private PlayerScore SelectPlayerScoreBoard(int topicNumber)
        {            
            switch (topicNumber)
            {
                case 0:
                    GetLTNameScoreBoard(ltName, player.PlayerId);
                    break;
                case 1:
                    GetLTCityScoreBoard(ltCity, player.PlayerId);
                    break;
                case 2:
                    GetCountryScoreBoard(country, player.PlayerId);
                    break;
                case 3:
                    GetFurnitureScoreBoard(furniture, player.PlayerId);
                    break;
            }
            return null;
        }
        private void SelectedWordGuessMechanics(int topicNumber)
        {
            switch (topicNumber)
            {
                case 0:
                    LTNameGuessMechanics(ltName);
                    break;
                case 1:
                    LTCityGuessMechanics(ltCity);
                    break;
                case 2:
                    CountryGuessMechanics(country);
                    break;
                case 3:
                    FurnitureGuessMechanics(furniture);
                    break;
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
        
        private PlayerScore GetLTNameScoreBoard(LTName word, int playerId)
        {
            return new PlayerScore
            {
                PlayerId = playerId,
                DatePlayed = DateTime.Now,
                GuessCount = _hiddenWordManager.IncorrectGuesesCount + _hiddenWordManager.HiddenWord.RevealdLetterCount,
                IsCorrect = !_hiddenWordManager.HasHiddenLetters,
                LTNameId = word.LTNameId,
            };
        }
        private PlayerScore GetLTCityScoreBoard(LTCity word, int playerId)
        {
            return new PlayerScore
            {
                PlayerId = playerId,
                DatePlayed = DateTime.Now,
                GuessCount = _hiddenWordManager.IncorrectGuesesCount + _hiddenWordManager.HiddenWord.RevealdLetterCount,
                IsCorrect = !_hiddenWordManager.HasHiddenLetters,
                LTCityId = word.LTCityId,
            };
        }
        private PlayerScore GetCountryScoreBoard(Country word, int playerId)
        {
            return new PlayerScore
            {
                PlayerId = playerId,
                DatePlayed = DateTime.Now,
                GuessCount = _hiddenWordManager.IncorrectGuesesCount + _hiddenWordManager.HiddenWord.RevealdLetterCount,
                IsCorrect = !_hiddenWordManager.HasHiddenLetters,
                CountryId = word.CountryId,
            };
        }
        private PlayerScore GetFurnitureScoreBoard(Furniture word, int playerId)
        {
            return new PlayerScore
            {
                PlayerId = playerId,
                DatePlayed = DateTime.Now,
                GuessCount = _hiddenWordManager.IncorrectGuesesCount + _hiddenWordManager.HiddenWord.RevealdLetterCount,
                IsCorrect = !_hiddenWordManager.HasHiddenLetters,
                FurnitureId = word.FurnitureId,
            };
        }
       
        private void LTNameGuessMechanics(LTName word)
        {
            if (_guess.CheckLTNameCorrect())
                _messagesRepository.WinGameMessage(word.Text);
            else
            {
                _messagesRepository.HangmanPictureMessage(maxLives);
                _messagesRepository.LostGameMessage(word.Text);
            }
        }
        private void LTCityGuessMechanics(LTCity word)
        {
            if (_guess.CheckLTCityCorrect())
                _messagesRepository.WinGameMessage(word.Text);
            else
            {
                _messagesRepository.HangmanPictureMessage(maxLives);
                _messagesRepository.LostGameMessage(word.Text);
            }
        }
        private void CountryGuessMechanics(Country word)
        {
            if (_guess.CheckCountryCorrect())
                _messagesRepository.WinGameMessage(word.Text);
            else
            {
                _messagesRepository.HangmanPictureMessage(maxLives);
                _messagesRepository.LostGameMessage(word.Text);
            }
        }
        private void FurnitureGuessMechanics(Furniture word)
        {
            if (_guess.CheckFurnitureCorrect())
                _messagesRepository.WinGameMessage(word.Text);
            else
            {
                _messagesRepository.HangmanPictureMessage(maxLives);
                _messagesRepository.LostGameMessage(word.Text);
            }
        }
    }    
}
