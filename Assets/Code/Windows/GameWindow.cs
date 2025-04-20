using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Windows
{
    public class GameWindow : Window
    {
        [SerializeField] private Button _settingsButton;
        private SettingsWindow _settingsWindow;

        [Inject]
        public void Initialize(SettingsWindow settingsWindow)
        {
            _settingsWindow = settingsWindow;
            _settingsButton.onClick.AddListener(OpenSettingsWindow);
        }

        private void OnDestroy()
        {
            _settingsButton.onClick.RemoveListener(OpenSettingsWindow);
        }

        private void OpenSettingsWindow()
        {
            _settingsWindow.Open();
        }
    }
}
