using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.DragAndDrop
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        public event Action<DragItem> DragItemDropped;
        [SerializeField] private Transform _content;

        public void OnDrop(PointerEventData eventData)
        {
            var dragItem = eventData.pointerDrag.GetComponent<DragItem>();
            if (dragItem == null)
            {
                return;
            }

            dragItem.transform.SetParent(_content);
            dragItem.SetLastParent(_content);
            DragItemDropped?.Invoke(dragItem);
        }
    }
}
