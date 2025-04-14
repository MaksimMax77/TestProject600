using UnityEngine;

namespace Code.Level.LevelSettings
{
    [CreateAssetMenu(fileName = nameof(LevelsConfigurationsName), menuName = nameof(LevelsConfigurationsName))]
    public class LevelsConfigurationsName : ScriptableObject
    {
        [SerializeField] private string _levelsConfigName = "levelConfigurations";

        public string LevelsConfigName => _levelsConfigName;
    }
}