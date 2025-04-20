using UnityEngine;

namespace Code.Level.GameField.Containers
{
    public class GameFieldRoots : MonoBehaviour
    {
        [SerializeField] private Transform _wordsRoot;
        [SerializeField] private Transform _clustersRoot;
        
        public Transform WordsRoot => _wordsRoot;
        public Transform ClustersRoot => _clustersRoot;
    }
}
