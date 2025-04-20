using Code.Core.Update;
using Code.DragAndDrop;
using Code.Level.DragControl;
using Code.Level.GameField.Containers;
using Code.Level.LevelCreation;
using Code.Level.LevelResult;
using Code.Level.LevelSettings;
using Code.RemoteConfigLoad;
using Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    { 
        [SerializeField] private Updater _updater; 
        [SerializeField] private CanvasComponentsContainer _canvasComponentsContainer;
        [SerializeField] private LevelsConfigurationsName _levelsConfigurationsName;
        [SerializeField] private WordFieldsContainerSettings _wordFieldsContainerSettings;
        [SerializeField] private CharactersClustersContainerSettings _charactersClustersContainerSettings;
        [SerializeField] private GameFieldRoots _gameFieldRoots;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private StartMenuWindow _startMenuWindow;
        [SerializeField] private ResultWindow _resultWindow;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_updater).AsSingle();
            Container.BindInstance(_canvasComponentsContainer).AsSingle();
            Container.BindInstance(_gameFieldRoots).AsSingle();
            Container.BindInstance(_settingsWindow).AsSingle();
            Container.BindInstance(_gameWindow).AsSingle();
            Container.BindInstance(_startMenuWindow).AsSingle();
            Container.BindInstance(_resultWindow).AsSingle();
            Container.BindInstance(_levelsConfigurationsName).AsSingle();
            Container.BindInstance(_wordFieldsContainerSettings).AsSingle();
            Container.BindInstance(_charactersClustersContainerSettings).AsSingle();
            
            Container.Bind<UnityServicesInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<RemoteConfigFetcher>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<LevelsConfigurationsLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<WordFieldsContainer>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharactersClustersContainer>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelCreator>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<LevelResultControl>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DragItemsControl>().AsSingle().NonLazy();
        }
    }
}