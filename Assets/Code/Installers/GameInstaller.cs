using Code.Level.LevelSettings;
using Code.RemoteConfigLoad;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LevelsConfigurationsName _levelsConfigurationsName;
        
        public override void InstallBindings()
        {
            Container.Bind<UnityServicesInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<RemoteConfigFetcher>().AsSingle();
            Container.BindInstance(_levelsConfigurationsName).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsConfigurationsLoader>().AsSingle().NonLazy();
        }
    }
}