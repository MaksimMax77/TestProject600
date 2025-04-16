using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.DragAndDrop
{
    public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _canvasGroup;
        private Canvas _canvas;
        private Transform _dragField;
        private bool _initialized;
        private Transform _lastParent;
        private bool _isDragging;

        public void Init(Transform startParent, Canvas canvas, Transform dragField)
        {
            SetLastParent(startParent);
            _canvas = canvas;
            _dragField = dragField;
            _initialized = true;
        }

        public void SetLastParent(Transform parent)
        {
            _lastParent = parent;
        }

        public void TryReturnOnLastParent()
        {
            if (!_initialized || _isDragging || transform.parent == _lastParent)
            {
                return;
            }

            _rectTransform.SetParent(_lastParent);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isDragging = true;
            _canvasGroup.blocksRaycasts = false;
            transform.SetParent(_dragField);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isDragging = false;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}