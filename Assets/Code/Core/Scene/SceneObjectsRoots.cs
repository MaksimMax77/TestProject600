using UnityEngine;

namespace Code.Core.Scene
{
    public class SceneObjectsRoots : MonoBehaviour
    {
        [SerializeField] private Transform _wordsRoot;
        [SerializeField] private Transform _clustersRoot;
        [SerializeField] private Transform _pooledItemsRoot;
        
        public Transform WordsRoot => _wordsRoot;
        public Transform ClustersRoot => _clustersRoot;
        public Transform PooledItemsRoot => _pooledItemsRoot;
    }
}
