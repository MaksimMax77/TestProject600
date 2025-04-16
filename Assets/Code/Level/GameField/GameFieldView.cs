using UnityEngine;

namespace Code.Level.GameField
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField] private Transform _wordsRoot;
        [SerializeField] private Transform _clustersRoot;
        [SerializeField] private Transform _dragField; 
        
        public Transform WordsRoot => _wordsRoot;
        public Transform ClustersRoot => _clustersRoot;
        public Transform DragField => _dragField;
    }
}
