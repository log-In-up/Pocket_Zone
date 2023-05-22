using UnityEngine;
using Inventory;

namespace Enemies
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class ItemDropper : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Health _health = null;
        #endregion

        #region Fields
        private ItemSpawner _spawner = null;
        #endregion

        #region MonoBehaviour API
        private void OnEnable()
        {
            _health.OnDeath += OnDeath;
        }

        private void OnDisable()
        {
            _health.OnDeath -= OnDeath;
        }
        #endregion

        #region Public Methods
        internal void Init(ItemSpawner itemSpawner) => _spawner = itemSpawner;
        #endregion

        #region Event Handlers
        private void OnDeath() => _spawner.GenerateRandomDrop(transform.position);
        #endregion
    }
}
