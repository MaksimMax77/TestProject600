using Code.Level.LevelSettings;

namespace Code.Level.GameField
{
    public class WordField
    {
        private string _currentWord;
        private WordConfiguration _wordConfiguration;
        private WordFieldView _wordFieldView;

        public void SetWordConfiguration(WordConfiguration wordConfiguration)
        {
            _wordConfiguration = wordConfiguration;
        }

        public void SetWordFieldView(WordFieldView wordFieldView)
        {
            _wordFieldView = wordFieldView;
        }
    }
}