using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Update
{
    public class Updater : MonoBehaviour
    {
        private List<IUpdatable> _updatableObjects = new();

        [Inject]
        public void Init(List<IUpdatable> updatableObjects)
        {
            _updatableObjects = updatableObjects;
            Debug.LogError(_updatableObjects.Count);
        }

        private void Update()
        {
            for (int i = 0; i < _updatableObjects.Count; i++)
            {
                _updatableObjects[i].ObjUpdate();
            }
        }
    }
}
