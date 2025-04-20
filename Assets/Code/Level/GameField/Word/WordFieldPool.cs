using Code.Pools;
using UnityEngine;

namespace Code.Level.GameField.Word
{
    public class WordFieldPool : ObjectPool<WordField>
    {
        private WordFieldView _wordFieldViewPrefab;

        public void SetViewPrefab(WordFieldView wordFieldViewPrefab)
        {
            _wordFieldViewPrefab = wordFieldViewPrefab;
        }
        
        protected override WordField CreateNewItem()
        {
            return new WordField(Object.Instantiate(_wordFieldViewPrefab));
        }

        public override void ReturnToPool(WordField item)
        {
            base.ReturnToPool(item);
            item.WordFieldView.gameObject.SetActive(false);
            item.WordFieldView.transform.SetParent(null);
        }

        public override WordField Get()
        {
            var item = base.Get();
            item.WordFieldView.gameObject.SetActive(true);
            return item;
        }
    }
}
