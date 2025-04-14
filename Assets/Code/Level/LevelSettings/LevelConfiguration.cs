using System;
using System.Collections.Generic;

namespace Code.Level.LevelSettings
{
    [Serializable]
    public class LevelConfiguration
    {
        public List<WordConfiguration> words;
    }

    [Serializable]
    public class WordConfiguration
    {
        public string expectedValue;
        public string[] clusters;
    }
}
