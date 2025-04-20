using System;
using Code.Level.LevelSettings;
using UnityEngine;

namespace Code.Level.GameField.Word
{
    public class WordField : IDisposable
    {
        public event Action CorrectFilled;
        private string _currentWord;
        private string _expectedWord;
        private WordFieldView _wordFieldView;
        private bool _isCorrectFilled;

        public bool IsCorrectFilled => _isCorrectFilled;
        public string CurrentWord => _currentWord;
        public WordFieldView WordFieldView => _wordFieldView;

        public WordField(WordFieldView wordFieldView)
        {
            _wordFieldView = wordFieldView;
            _wordFieldView.ClusterDropped += OnClusterDropped;
            _wordFieldView.ClusterRemoved += RemoveChars;
        }

        public void Reset()
        {
            _wordFieldView.SetBlocker(false);
            _isCorrectFilled = false;
            _currentWord = string.Empty;
        }
        
        public void SetExpectedWord(string expectedWord)
        {
            _expectedWord = expectedWord;
        }
        
        public void Dispose()
        {
            _wordFieldView.ClusterDropped -= OnClusterDropped;
            _wordFieldView.ClusterRemoved -= RemoveChars;
        }

        private void OnClusterDropped(string characters)
        {
            _currentWord += characters;

            if (!CheckOccupancy() || !CheckValueIsCorrect())
            {
                return;
            }

            _wordFieldView.SetBlocker(true);
            _isCorrectFilled = true;
            CorrectFilled?.Invoke();
        }

        private bool CheckOccupancy()
        {
            return _currentWord.Length == _expectedWord.Length;
        }

        private bool CheckValueIsCorrect()
        {
            return string.Equals(_currentWord, _expectedWord);
        }

        private void RemoveChars(string characters)
        {
            var index = _currentWord.IndexOf(characters, StringComparison.Ordinal);
            _currentWord = index < 0 ? _currentWord : _currentWord.Remove(index, characters.Length);
        }
    }
}