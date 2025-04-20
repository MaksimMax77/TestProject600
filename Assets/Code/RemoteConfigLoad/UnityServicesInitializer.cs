using System;
using Cysharp.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using Zenject;

namespace Code.RemoteConfigLoad
{
    public class UnityServicesInitializer
    {
        public event Action OnInitialized;
        
        [Inject]
        private async void InitializeAsync()
        {
            try
            {
                await InitializeRemoteConfigAsync();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private async UniTask InitializeRemoteConfigAsync()
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }
            
            OnInitialized?.Invoke();
        }
    }
}
