using System;
using System.Collections.Generic;
using Code.Level.GameField;
using Code.Level.GameField.Cluster;
using Code.Level.GameField.Word;
using Code.Level.LevelSettings;
using Object = UnityEngine.Object;

namespace Code.Level.LevelCreation
{
    public class LevelCreator : IDisposable
    {
        public event Action<CharactersCluster> CharactersClusterViewCreated;
        private LevelsConfigurationsLoader _levelsConfigurationsLoader;
        private WordFieldView _wordFieldViewPrefab;
        private CharactersCluster _charactersClusterPrefab;
        private GameFieldView _gameFieldView;
        private List<WordField> _wordFields = new();
        private int _currentLevel;

        public LevelCreator(LevelsConfigurationsLoader levelsConfigurationsLoader,
            LevelCreatorSettings levelCreatorSettings, GameFieldView gameFieldView)
        {
            _levelsConfigurationsLoader = levelsConfigurationsLoader;
            _wordFieldViewPrefab = levelCreatorSettings.WordFieldViewPrefab;
            _charactersClusterPrefab = levelCreatorSettings.CharactersClusterPrefab;
            _gameFieldView = gameFieldView;
            _levelsConfigurationsLoader.LevelsConfigurationsLoaded += Create;
        }

        public void Dispose()
        {
            _levelsConfigurationsLoader.LevelsConfigurationsLoaded -= Create;

            for (int i = 0, count = _wordFields.Count; i < count; ++i)
            {
                _wordFields[i].Dispose();
            }
        }

        private void Create(LevelsConfigsContainer levelsConfigsContainer)
        {
            var levelConfiguration = levelsConfigsContainer.levelConfigurations[_currentLevel];
            CreateWordsFields(levelConfiguration);
            CreateClusters(levelConfiguration);
        }

        private void CreateWordsFields(LevelConfiguration levelConfiguration)
        {
            var words = levelConfiguration.words;
            
            for (int i = 0, len = words.Count; i < len; ++i)
            {
                var wordFieldView = Object.Instantiate(_wordFieldViewPrefab, _gameFieldView.WordsRoot);
                var wordField = new WordField(words[i], wordFieldView);
                _wordFields.Add(wordField);
            }
        }

        private void CreateClusters(LevelConfiguration levelConfiguration)
        {
            var words = levelConfiguration.words;
            for (int i = 0, count = words.Count; i < count; ++i)
            {
                var clusters = words[i].clusters;
                
                for (int j = 0, countj = clusters.Length; j < countj; ++j)
                {
                    var view = Object.Instantiate(_charactersClusterPrefab, _gameFieldView.ClustersRoot);
                    view.SetCharactersAndText(clusters[j]);
                    CharactersClusterViewCreated?.Invoke(view);
                }
            }
        }
    }
}