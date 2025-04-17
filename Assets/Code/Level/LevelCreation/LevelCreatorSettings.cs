using Code.Level.GameField.Cluster;
using Code.Level.GameField.Word;
using UnityEngine;

namespace Code.Level.LevelCreation
{
    [CreateAssetMenu(fileName = nameof(LevelCreatorSettings), menuName = nameof(LevelCreatorSettings))]
    public class LevelCreatorSettings : ScriptableObject
    {
        [SerializeField] private WordFieldView _wordFieldViewPrefab;
        [SerializeField] private CharactersCluster charactersClusterPrefab;
        
        public WordFieldView WordFieldViewPrefab => _wordFieldViewPrefab;
        public CharactersCluster CharactersClusterPrefab => charactersClusterPrefab;
    }
}
