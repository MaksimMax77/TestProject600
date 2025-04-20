using Code.Level.GameField.Cluster;
using UnityEngine;

namespace Code.Level.GameField.Containers
{
    [CreateAssetMenu(fileName = nameof(CharactersClustersContainerSettings),
        menuName = nameof(CharactersClustersContainerSettings))]
    public class CharactersClustersContainerSettings : ScriptableObject
    {
        [SerializeField] private CharactersCluster _charactersClusterPrefab;
        
        public CharactersCluster CharactersClusterPrefab => _charactersClusterPrefab;
    }
}
