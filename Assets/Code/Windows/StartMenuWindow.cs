using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Windows
{
    public class StartMenuWindow : Window
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        private SettingsWindow _settingsWindow;

        [Inject]
        public void Initialize(SettingsWindow settingsWindow)
        {
            _settingsWindow = settingsWindow;
            _playButton.onClick.AddListener(Close);
            _settingsButton.onClick.AddListener(OpenSettingsWindow);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(Close);
            _settingsButton.onClick.RemoveListener(OpenSettingsWindow);
        }

        private void OpenSettingsWindow()
        {
            _settingsWindow.Open();
        }
    }
}
