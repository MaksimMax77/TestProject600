using Code.Level.GameField;
using UnityEngine;

namespace Code.Level.LevelCreation
{
    [CreateAssetMenu(fileName = nameof(LevelCreatorSettings), menuName = nameof(LevelCreatorSettings))]
    public class LevelCreatorSettings : ScriptableObject
    {
        [SerializeField] private WordFieldView _wordFieldViewPrefab;
        [SerializeField] private CharactersClusterView _charactersClusterViewPrefab;
        
        public WordFieldView WordFieldViewPrefab => _wordFieldViewPrefab;
        public CharactersClusterView CharactersClusterViewPrefab => _charactersClusterViewPrefab;
    }
}
