using Code.DragAndDrop;
using UnityEngine;

namespace Code.Level.GameField
{
    public class WordFieldView : MonoBehaviour
    {
        [SerializeField] private DropSlot _dropSlot;

        private void Awake()
        {
            _dropSlot.DragItemDropped += OnDragItemDropped;
        }

        private void OnDestroy()
        {
            _dropSlot.DragItemDropped -= OnDragItemDropped;
        }

        private void OnDragItemDropped(DragItem dragItem)
        {
            
        }
    }
}
