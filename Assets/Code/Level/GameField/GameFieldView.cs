using UnityEngine;

namespace Code.Level.GameField
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField] private Transform _wordsRoot;
        
        public Transform WordsRoot => _wordsRoot;
    }
}
