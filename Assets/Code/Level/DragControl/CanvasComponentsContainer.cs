using UnityEngine;

namespace Code.Level.DragControl
{
    public class CanvasComponentsContainer : MonoBehaviour
    {
        [SerializeField] private RectTransform _dragItemsParent;
        [SerializeField] private Canvas _canvas;
        
        public RectTransform DragItemsParent => _dragItemsParent;
        public Canvas Canvas => _canvas;
    }
}
