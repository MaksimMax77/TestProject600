using Code.Level.GameField.Word;
using UnityEngine;

namespace Code.Level.GameField.Containers
{
    [CreateAssetMenu(fileName = nameof(WordFieldsContainerSettings),
        menuName = nameof(WordFieldsContainerSettings))]
    public class WordFieldsContainerSettings : ScriptableObject
    {
        [SerializeField] private WordFieldView _wordFieldViewPrefab;

        public WordFieldView WordFieldViewPrefab => _wordFieldViewPrefab;
    }
}