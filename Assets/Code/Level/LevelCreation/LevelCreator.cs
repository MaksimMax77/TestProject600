using System;
using System.Collections.Generic;
using Code.Level.GameField.Containers;
using Code.Level.LevelSettings;
using Code.Windows;

namespace Code.Level.LevelCreation
{
    public class LevelCreator : IDisposable
    {
        private LevelsConfigurationsLoader _levelsConfigurationsLoader;
        private int _currentLevel; 
        private ResultWindow _resultWindow;
        private List<LevelConfiguration> _levelConfigurations;
        private WordFieldsContainer _wordFieldsContainer;
        private CharactersClustersContainer _charactersClustersContainer;

        public LevelCreator(
            LevelsConfigurationsLoader levelsConfigurationsLoader, 
            WordFieldsContainer wordFieldsContainer,
            CharactersClustersContainer charactersClustersContainer, 
            ResultWindow resultWindow)
        {
            _levelsConfigurationsLoader = levelsConfigurationsLoader; 
            _wordFieldsContainer = wordFieldsContainer;
            _charactersClustersContainer = charactersClustersContainer;
            _resultWindow = resultWindow;
            _levelsConfigurationsLoader.LevelsConfigurationsLoaded += OnLevelsConfigurationsLoaded;
            _resultWindow.NextLevelButtonClicked += OnNextLevelClicked;
            _resultWindow.MainMenuButtonClicked += LoadFirstLevel;
        }

        public void Dispose()
        {
            _levelsConfigurationsLoader.LevelsConfigurationsLoaded -= OnLevelsConfigurationsLoaded;
            _resultWindow.NextLevelButtonClicked -= OnNextLevelClicked;
            _resultWindow.MainMenuButtonClicked -= LoadFirstLevel;
        }

        private void LoadFirstLevel()
        {
            _currentLevel = 0;
            PutElementsToPools();
            Create();
        }
        
        private void OnLevelsConfigurationsLoaded(LevelsConfigsContainer levelsConfigsContainer)
        {
            _levelConfigurations = levelsConfigsContainer.levelConfigurations;
            Create();
        }
        
        private void OnNextLevelClicked()
        {
            IncrementCurrentLevel();
            PutElementsToPools();
            Create();
        }

        private void IncrementCurrentLevel()
        {
            ++_currentLevel;
            if (_currentLevel >= _levelConfigurations.Count)
            {
                _currentLevel = 0;
            }
        }

        private void PutElementsToPools()
        {
            _wordFieldsContainer.Reset();
            _charactersClustersContainer.Reset();
        }

        private void Create()
        {
            var levelConfiguration = _levelConfigurations[_currentLevel];
            _wordFieldsContainer.Create(levelConfiguration);
            _charactersClustersContainer.Create(levelConfiguration);
        }
    }
}