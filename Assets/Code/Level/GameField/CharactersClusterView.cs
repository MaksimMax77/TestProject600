using TMPro;
using UnityEngine;

namespace Code.Level.GameField
{
    public class CharactersClusterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;

        public void SetText(string text)
        {
            _tmpText.text = text;
        }
    }
}
