using System;
using Code.Level.LevelSettings;

namespace Code.Level.GameField.Word
{
    public class WordField : IDisposable
    {
        private string _currentWord;
        private string _expectedWord;
        private WordFieldView _wordFieldView;

        public WordField(WordConfiguration wordConfiguration, WordFieldView wordFieldView)
        {
            _expectedWord = wordConfiguration.expectedValue;
            _wordFieldView = wordFieldView;
            _wordFieldView.ClusterDropped += OnClusterDropped;
            _wordFieldView.ClusterRemoved += RemoveChars;
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