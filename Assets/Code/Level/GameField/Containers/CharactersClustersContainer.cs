using System;
using System.Collections.Generic;
using Code.Core.Pools;
using Code.Level.GameField.Cluster;
using Code.Level.LevelSettings;
using UnityEngine;

namespace Code.Level.GameField.Containers
{
    public class CharactersClustersContainer
    {
        public event Action<CharactersCluster> CharactersClusterCreated;
        private Transform _parent;
        private MonoBehaviourPool<CharactersCluster> _charactersClusterPool;
        private List<CharactersCluster> _charactersClusters = new();

        public CharactersClustersContainer(CharactersClustersContainerSettings charactersClustersContainerSettings, GameFieldRoots gameFieldRoots)
        {
            _charactersClusterPool = new MonoBehaviourPool<CharactersCluster>();
            _charactersClusterPool.SetPrefab(charactersClustersContainerSettings.CharactersClusterPrefab);
            _charactersClusterPool.Create();
            _parent = gameFieldRoots.ClustersRoot;
        }

        public void Reset()
        {
            for (int i = 0, count = _charactersClusters.Count; i < count; i++)
            {
                _charactersClusterPool.ReturnToPool(_charactersClusters[i]);
            }
            
            _charactersClusters.Clear();
        }
        
        public void Create(LevelConfiguration levelConfiguration)
        {
            var words = levelConfiguration.words;
            for (int i = 0, count = words.Count; i < count; ++i)
            {
                var clusters = words[i].clusters;

                for (int j = 0, countj = clusters.Length; j < countj; ++j)
                {
                    var charactersCluster = _charactersClusterPool.Get();
                    charactersCluster.transform.SetParent(_parent);
                    charactersCluster.SetCharactersAndText(clusters[j]);
                    _charactersClusters.Add(charactersCluster);
                    CharactersClusterCreated?.Invoke(charactersCluster);
                }
            }
        }
    }
}
