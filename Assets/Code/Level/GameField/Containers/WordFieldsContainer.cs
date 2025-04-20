using System;
using System.Collections.Generic;
using Code.Core.Scene;
using Code.Level.GameField.Word;
using Code.Level.LevelSettings;
using UnityEngine;

namespace Code.Level.GameField.Containers
{
    public class WordFieldsContainer : IDisposable
    {
        public event Action<WordField> WordFieldCreated;
        private WordFieldView _wordFieldViewPrefab;
        private WordFieldPool _wordFieldPool;
        private Transform _creationParent;
        private List<WordField> _wordFields = new();

        public WordFieldsContainer(WordFieldsContainerSettings settings, SceneObjectsRoots sceneObjectsRoots)
        {
            _wordFieldViewPrefab = settings.WordFieldViewPrefab;
            _creationParent = sceneObjectsRoots.WordsRoot;
            _wordFieldPool = new WordFieldPool();
            _wordFieldPool.SetViewPrefab(_wordFieldViewPrefab);
            _wordFieldPool.SetParent(sceneObjectsRoots.PooledItemsRoot);
            _wordFieldPool.Create();
        }
        
        public void Create(LevelConfiguration levelConfiguration)
        {
            var words = levelConfiguration.words;

            for (int i = 0, len = words.Count; i < len; ++i)
            {
                var wordField = _wordFieldPool.Get();
                wordField.WordFieldView.transform.SetParent(_creationParent);
                wordField.WordFieldView.transform.localScale = Vector3.one;
                wordField.SetExpectedWord(words[i].expectedValue);
                _wordFields.Add(wordField);
                WordFieldCreated?.Invoke(wordField);
            }
        }

        public void Reset()
        {
            for (int i = 0, count = _wordFields.Count; i < count; ++i)
            {
                var wordField = _wordFields[i];
                wordField.WordFieldView.SetBlocker(false);
                wordField.Reset();
                _wordFieldPool.ReturnToPool(wordField);
            }
            _wordFields.Clear();
        }

        public void Dispose()
        {
            for (int i = 0, count = _wordFields.Count; i < count; ++i)
            {
                _wordFields[i].Dispose();
            }

            var pooled = _wordFieldPool.Pooled;

            for (int i = 0, count = pooled.Count; i < count; ++i)
            {
                pooled[i].Dispose();
            }
        }
    }
}
