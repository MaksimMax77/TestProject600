using UnityEngine;

namespace Code.Core.Pools
{
    public class MonoBehaviourPool<T> : ObjectPoolWithParent<T> where T : MonoBehaviour
    {
        protected T _prefab;
        
        public void SetPrefab(T prefab)
        {
            _prefab = prefab;
        }
        
        protected override T CreateNewItem()
        {
            return Object.Instantiate(_prefab);
        }

        public override void ReturnToPool(T item)
        {
            base.ReturnToPool(item);
            item.gameObject.SetActive(false);
            item.transform.SetParent(_parent);
        }

        public override T Get()
        {
            var item = base.Get();
            item.gameObject.SetActive(true);
            return item;
        }
    }
}