using Code.DragAndDrop;
using Code.Level.GameField;
using Code.Level.LevelCreation;
using Code.Level.LevelSettings;
using Code.RemoteConfigLoad;
using Code.Update;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LevelsConfigurationsName _levelsConfigurationsName;
        [SerializeField] private LevelCreatorSettings _levelCreatorSettings;
        [SerializeField] private CanvasComponentsContainer _canvasComponentsContainer;
        [SerializeField] private GameFieldView _gameFieldView;
        [SerializeField] private Updater _updater;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_updater).AsSingle();
            Container.Bind<UnityServicesInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<RemoteConfigFetcher>().AsSingle();
            Container.BindInstance(_levelsConfigurationsName).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsConfigurationsLoader>().AsSingle();   
            Container.BindInstance(_levelCreatorSettings).AsSingle();
            Container.BindInstance(_gameFieldView).AsSingle();
            Container.Bind<LevelCreator>().AsSingle();
            Container.BindInstance(_canvasComponentsContainer);
            Container.BindInterfacesAndSelfTo<DragItemsControl>().AsSingle().NonLazy();
        }
    }
}