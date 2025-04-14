using System;
using Code.RemoteConfigLoad;
using Unity.Services.RemoteConfig;
using UnityEngine;

namespace Code.Level.LevelSettings
{
    public class LevelsConfigurationsLoader: IDisposable
    {
        public event Action<LevelsConfigsContainer> LevelsConfigurationsLoaded;
        private RemoteConfigFetcher _remoteConfigFetcher;
        private string _configName;

        public LevelsConfigurationsLoader(RemoteConfigFetcher remoteConfigFetcher, 
            LevelsConfigurationsName levelsConfigurationsName)
        {
            _remoteConfigFetcher = remoteConfigFetcher;
            _configName = levelsConfigurationsName.LevelsConfigName;
            _remoteConfigFetcher.ConfigLoaded += OnConfigLoaded;
        }

        public void Dispose()
        {
            _remoteConfigFetcher.ConfigLoaded -= OnConfigLoaded;
        }

        private void OnConfigLoaded(RuntimeConfig config)
        {
            var jsonCubeString = config.GetJson(_configName);
            var configsInfo = new LevelsConfigsContainer();
            JsonUtility.FromJsonOverwrite(jsonCubeString, configsInfo);  
            LevelsConfigurationsLoaded?.Invoke(configsInfo);
            Debug.Log(configsInfo);//todo to remove 
        }
    }
}
