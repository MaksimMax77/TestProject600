using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.DragAndDrop
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        public event Action<DragItem> DragItemDropped;
        public event Action<DragItem> DragItemRemoved;
        [SerializeField] private Transform _content;
        [SerializeField] private int _elementsMaxAmount = 3;
        private List<DragItem> _draggedItems = new List<DragItem>();

        public void OnDrop(PointerEventData eventData)
        {
            var dragItem = eventData.pointerDrag.GetComponent<DragItem>();
            if (dragItem == null || CheckOccupancy())
            {
                return;
            }

            dragItem.transform.SetParent(_content);
            dragItem.SetLastParent(_content);
            _draggedItems.Add(dragItem);
            dragItem.BeginDrag += OnChildDrag;
            DragItemDropped?.Invoke(dragItem);
        }

        private bool CheckOccupancy()
        {
            return _content.childCount >= _elementsMaxAmount;
        }

        private void OnChildDrag(DragItem dragItem)
        {
            dragItem.BeginDrag -= OnChildDrag;
            _draggedItems.Remove(dragItem);
            DragItemRemoved?.Invoke(dragItem);
        }

        private void OnDestroy()
        {
            for (int i = 0, count =_draggedItems.Count; i< count; ++i)
            {
                _draggedItems[i].BeginDrag -= OnChildDrag;
            }
        }
    }
}
