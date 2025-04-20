using System.Collections.Generic;

namespace Code.Pools
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
        
        protected abstract T CreateNewItem();

        public virtual void ReturnToPool(T item)
        {
            _pooled.Add(item);
        }
    }
}
