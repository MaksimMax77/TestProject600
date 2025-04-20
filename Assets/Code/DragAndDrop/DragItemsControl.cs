using System;
using System.Collections.Generic;
using Code.Level.GameField.Cluster;
using Code.Level.GameField.Containers;
using Code.Update;

namespace Code.DragAndDrop
{
    public class DragItemsControl : IDisposable, IUpdatable
    {
        private List<DragItem> _dragItems = new();
        private CharactersClustersContainer _charactersClustersContainer;
        private CanvasComponentsContainer _canvasComponentsContainer;
        
        public DragItemsControl(CharactersClustersContainer charactersClustersContainer,
            CanvasComponentsContainer canvasComponentsContainer)
        {
            _charactersClustersContainer = charactersClustersContainer;
            _canvasComponentsContainer = canvasComponentsContainer;
            _charactersClustersContainer.CharactersClusterCreated += OnCharactersClusterCreated;
        }
        
        public void Dispose()
        {
            _charactersClustersContainer.CharactersClusterCreated -= OnCharactersClusterCreated;
        }
        
        private void OnCharactersClusterCreated(CharactersCluster charactersCluster)
        {
            var dragItem = charactersCluster.GetComponent<DragItem>();
            if (dragItem == null)
            {
                return;
            }
            
            dragItem.Init(dragItem.transform.parent, _canvasComponentsContainer.Canvas, 
                _canvasComponentsContainer.DragItemsParent);
            _dragItems.Add(dragItem);
        }

        public void ObjUpdate()
        {
            for (int i = 0, count = _dragItems.Count; i < count; ++i)
            {
                _dragItems[i].TryReturnOnLastParent();
            }
        }
    }
}
