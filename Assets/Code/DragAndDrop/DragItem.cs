using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.DragAndDrop
{
    public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Transform _dragField;

        private Transform _lastParent;
        private bool _isDragging;

        private void Awake()
        {
            SetLastParent(_rectTransform.parent);
        }

        public void SetLastParent(Transform parent)
        {
            _lastParent = parent;
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

        private void Update()
        {
            if (_isDragging || transform.parent == _lastParent)
            {
                return;
            }

            _rectTransform.SetParent(_lastParent);
        }
    }
}