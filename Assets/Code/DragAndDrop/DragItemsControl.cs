using System;
using System.Collections.Generic;
using Code.Level.GameField;
using Code.Level.LevelCreation;
using Code.Update;

namespace Code.DragAndDrop
{
    public class DragItemsControl : IDisposable, IUpdatable
    {
        private List<DragItem> _dragItems = new();
        private LevelCreator _levelCreator;
        private CanvasComponentsContainer _canvasComponentsContainer;
        
        public DragItemsControl(LevelCreator levelCreator, CanvasComponentsContainer canvasComponentsContainer)
        {
            _levelCreator = levelCreator;
            _canvasComponentsContainer = canvasComponentsContainer;
            _levelCreator.CharactersClusterViewCreated += OnCharactersClusterViewCreated;
        }
        
        public void Dispose()
        {
            _levelCreator.CharactersClusterViewCreated -= OnCharactersClusterViewCreated;
        }
        
        private void OnCharactersClusterViewCreated(CharactersClusterView charactersClusterView)
        {
            var dragItem = charactersClusterView.GetComponent<DragItem>();
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
