using TMPro;
using UnityEngine;

namespace Code.Level.GameField.Cluster
{
    public class CharactersCluster : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        private string _characters;

        public string GetCharacters()
        {
            return _characters;
        }

        public void SetCharactersAndText(string characters)
        {
            _characters = characters;
            SetText(characters);
        }

        private void SetText(string text)
        {
            _tmpText.text = text;
        }
    }
}
