using System;
using System.Threading.Tasks;
using Code.LevelSettings;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using UnityEngine;

namespace Code
{
    public class RemoteConfigManager : MonoBehaviour
    {
        private RemoteConfigService _remoteConfigService;

        private async void Awake()
        {
            try
            {
                await InitializeRemoteConfigAsync();
                _remoteConfigService = RemoteConfigService.Instance;
                _remoteConfigService.FetchCompleted += ApplyRemoteConfig;
                await _remoteConfigService.FetchConfigsAsync(new UserAttributes(), new AppAttributes());
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private async Task InitializeRemoteConfigAsync()
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }
        }

        private void OnDestroy()
        {
            _remoteConfigService.FetchCompleted -= ApplyRemoteConfig;
        }

        private void ApplyRemoteConfig(ConfigResponse configResponse)
        {
            if (configResponse.requestOrigin == ConfigOrigin.Remote)
            {
                var jsonCubeString = _remoteConfigService.appConfig.GetJson("levelConfigurations");
                var levelsConfigsInfo = new LevelsConfigsInfo();
                JsonUtility.FromJsonOverwrite(jsonCubeString, levelsConfigsInfo);
                Debug.LogError(levelsConfigsInfo);
            }
        }
    }

    public struct UserAttributes
    {
    }

    public struct AppAttributes
    {
    }
}