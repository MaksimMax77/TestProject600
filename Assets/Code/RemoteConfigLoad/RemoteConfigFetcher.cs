using System;
using Unity.Services.RemoteConfig;

namespace Code.RemoteConfigLoad
{
    public class RemoteConfigFetcher: IDisposable
    {
        public event Action<RuntimeConfig> ConfigLoaded;
        private readonly UnityServicesInitializer _unityServicesInitializer;
        private readonly RemoteConfigService _remoteConfigService;
        
        public RemoteConfigFetcher(UnityServicesInitializer unityServicesInitializer)
        {
            _unityServicesInitializer = unityServicesInitializer;
            _remoteConfigService = RemoteConfigService.Instance;
            _remoteConfigService.FetchCompleted += OnFetchCompleted;
            _unityServicesInitializer.OnInitialized += OnServicesInitializerInitialized;
        }
        public void Dispose()
        {
            _unityServicesInitializer.OnInitialized -= OnServicesInitializerInitialized;
            _remoteConfigService.FetchCompleted -= OnFetchCompleted;
        }

        private void OnServicesInitializerInitialized()
        {
             _remoteConfigService.FetchConfigs(new UserAttributes(), new AppAttributes());
        }

        private void OnFetchCompleted(ConfigResponse configResponse)
        {
            if (configResponse.requestOrigin == ConfigOrigin.Remote)
            {
                ConfigLoaded?.Invoke( _remoteConfigService.appConfig);
            }
        }
    }
    
    public struct UserAttributes { }

    public struct AppAttributes { }
}
