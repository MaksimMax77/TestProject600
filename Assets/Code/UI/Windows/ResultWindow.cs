using System;
using System.Collections.Generic;
using Code.Core.Pools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows
{
    public class ResultWindow : Window
    {
        public event Action MainMenuButtonClicked;
        public event Action NextLevelButtonClicked;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private TMP_Text _wordPrefab;
        [SerializeField] private Transform _wordsRoot;
        private StartMenuWindow _startMenuWindow;
        private MonoBehaviourPool<TMP_Text> _textPool;
        private List<TMP_Text> _texts = new();

        [Inject]
        public void Initialize(StartMenuWindow startMenuWindow)
        {
            _textPool = new MonoBehaviourPool<TMP_Text>();
            _textPool.SetPrefab(_wordPrefab);
            _textPool.Create();
            _startMenuWindow = startMenuWindow;
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            _nextLevelButton.onClick.AddListener(NextLevelButtonClickedInvoke);
            _mainMenuButton.onClick.AddListener(Close);
            _nextLevelButton.onClick.AddListener(Close);
        }

        public void OnDestroy()
        {
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            _nextLevelButton.onClick.RemoveListener(NextLevelButtonClickedInvoke);
            _mainMenuButton.onClick.RemoveListener(Close);
            _nextLevelButton.onClick.RemoveListener(Close);
        }

        public void ResetTexts()
        {
            for (int i = 0, count = _texts.Count; i < count; i++)
            {
                _textPool.ReturnToPool(_texts[i]);
            }
            
            _texts.Clear();
        }

        public void SetWords(List<string> words)
        {
            for (int i = 0, count = words.Count; i < count; i++)
            {
                var text = _textPool.Get();
                text.transform.SetParent(_wordsRoot);
                text.text = words[i];
                _texts.Add(text);
            }
        }
        
        private void OnMainMenuButtonClicked()
        {
            _startMenuWindow.Open();
            MainMenuButtonClicked?.Invoke();
        }
        
        private void NextLevelButtonClickedInvoke()
        {
            NextLevelButtonClicked?.Invoke();
        }
    }
}
