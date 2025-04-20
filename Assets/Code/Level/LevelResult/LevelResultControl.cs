using System;
using System.Collections.Generic;
using Code.Level.GameField.Containers;
using Code.Level.GameField.Word;
using Code.UI.Windows;

namespace Code.Level.LevelResult
{
    public class LevelResultControl : IDisposable
    {
        private WordFieldsContainer _wordFieldsContainer;
        private List<WordField> _wordFields = new();
        private List<string> _words = new();
        private ResultWindow _resultWindow;

        public LevelResultControl(WordFieldsContainer wordFieldsContainer, ResultWindow resultWindow)
        {
            _wordFieldsContainer = wordFieldsContainer;
            _resultWindow = resultWindow;
            _wordFieldsContainer.WordFieldCreated += OnWordFieldCreated;
        }

        public void Dispose()
        {
            _wordFieldsContainer.WordFieldCreated -= OnWordFieldCreated;

            for (int i = 0, count = _wordFields.Count; i < count; ++i)
            {
                _wordFields[i].CorrectFilled -= OnWordFieldCorrectFilled;
            }
        }

        private void OnWordFieldCreated(WordField wordField)
        {
            wordField.CorrectFilled += OnWordFieldCorrectFilled;
            _wordFields.Add(wordField);
        }

        private void OnWordFieldCorrectFilled()
        {
            _words.Clear();

            if (_wordFields.Count == 0)
            {
                return;
            }

            for (int i = 0, count = _wordFields.Count; i < count; ++i)
            {
                var wordField = _wordFields[i];
                if (!wordField.IsCorrectFilled)
                {
                    return;
                }

                _words.Add(wordField.CurrentWord);
            }
            
            _wordFields.Clear();
            _resultWindow.ResetTexts();
            _resultWindow.SetWords(_words);
            _resultWindow.Open();
        }
    }
}