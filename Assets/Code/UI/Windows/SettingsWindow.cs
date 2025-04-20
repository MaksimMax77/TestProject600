using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows
{
    public class SettingsWindow : Window
    {
        public event Action<bool> SoundToggleChanged;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Button _closeButton;

        [Inject]
        public void Initialize()
        {
            _soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            _soundToggle.onValueChanged.RemoveListener(OnSoundToggleChanged);
            _closeButton.onClick.RemoveListener(Close);
        }

        private void OnSoundToggleChanged(bool value)
        {
            SoundToggleChanged?.Invoke(value);
        }
    }
}
