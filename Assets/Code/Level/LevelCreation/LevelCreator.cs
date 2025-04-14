using System;
using Code.Level.GameField;
using Code.Level.LevelSettings;
using Object = UnityEngine.Object;

namespace Code.Level.LevelCreation
{
    public class LevelCreator : IDisposable
    {
        private LevelsConfigurationsLoader _levelsConfigurationsLoader;
        private WordFieldView _wordFieldViewPrefab;
        private GameFieldView _gameFieldView;
        private int _currentLevel;

        public LevelCreator(LevelsConfigurationsLoader levelsConfigurationsLoader,
            LevelCreatorSettings levelCreatorSettings, GameFieldView gameFieldView)
        {
            _levelsConfigurationsLoader = levelsConfigurationsLoader;
            _wordFieldViewPrefab = levelCreatorSettings.WordFieldViewPrefab;
            _gameFieldView = gameFieldView;
            _levelsConfigurationsLoader.LevelsConfigurationsLoaded += Create;
        }

        public void Dispose()
        {
            _levelsConfigurationsLoader.LevelsConfigurationsLoaded -= Create;
        }

        private void Create(LevelsConfigsContainer levelsConfigsContainer)
        {
           var levelConfiguration = levelsConfigsContainer.levelConfigurations[_currentLevel];
            CreateWordsFields(levelConfiguration);
        }

        private void CreateWordsFields(LevelConfiguration levelConfiguration)
        {
            var words = levelConfiguration.words;
            
            for (int i = 0, len = words.Count; i < len; ++i)
            {
                var wordFieldView = Object.Instantiate(_wordFieldViewPrefab, _gameFieldView.WordsRoot);
                var wordField = new WordField();
                wordField.SetWordConfiguration(words[i]);
                wordField.SetWordFieldView(wordFieldView);
            }
        }
    }
}