using System.Collections.Generic;
using UnityEngine;

namespace Code.Core.Pools
{
    public abstract class ObjectPool<T>
    {
        private List<T> _pooled = new List<T>();
        
        public List<T> Pooled => _pooled;

        public void Create(int amount = 5)
        {
            for (int i = 0; i < amount; i++)
            {
                ReturnToPool(CreateNewItem());
            }
        }

        public virtual T Get()
        {
            if (_pooled.Count == 0)
            {
                var createdItem = CreateNewItem();
                return createdItem;
            }

            var item = _pooled[0];
            _pooled.Remove(item);
            return item;
        }

        protected virtual T CreateNewItem()
        {
            return default(T);
        }

        public virtual void ReturnToPool(T item)
        {
            _pooled.Add(item);
        }
    }

    public abstract class ObjectPoolWithParent<T> : ObjectPool<T>
    {
        protected Transform _parent;

        public void SetParent(Transform parent)
        {
            _parent = parent;
        }
    }
}
