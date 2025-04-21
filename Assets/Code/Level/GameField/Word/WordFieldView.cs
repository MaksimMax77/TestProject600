using Code.DragAndDrop;
using Code.Level.GameField.Cluster;
using System;
using Code.Core.DragAndDrop;
using UnityEngine;

namespace Code.Level.GameField.Word
{
    public class WordFieldView : MonoBehaviour
    {
        public event Action<string> ClusterDropped;
        public event Action<string> ClusterRemoved;
        [SerializeField] private DropSlot _dropSlot;
        [SerializeField] private GameObject _blocker;

        private void Awake()
        {
            _dropSlot.DragItemDropped += OnDragItemDropped;
            _dropSlot.DragItemRemoved += OnDragItemRemoved;
        }

        private void OnDestroy()
        {
            _dropSlot.DragItemDropped -= OnDragItemDropped;
        }

        public void SetBlocker(bool value)
        {
            _blocker.SetActive(value);
        }

        private void OnDragItemDropped(DragItem dragItem)
        {
            var charactersCluster = dragItem.GetComponent<CharactersCluster>();
            if (charactersCluster == null)
            {
                return;
            }
            ClusterDropped?.Invoke(charactersCluster.GetCharacters());
        }

        private void OnDragItemRemoved(DragItem dragItem)
        {
            var charactersCluster = dragItem.GetComponent<CharactersCluster>();
            if (charactersCluster == null)
            {
                return;
            }
            
            ClusterRemoved?.Invoke(charactersCluster.GetCharacters());
        }
    }
}
